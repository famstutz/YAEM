// -----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace YAEM.TestClient
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.ServiceModel;
    using System.Threading;
    using System.Windows.Forms;
    using Domain;
    using Domain.Utilities;
    using Services;

    /// <summary>
    /// Contains the logic for the <see cref="MainForm"/>.
    /// </summary>
    [CallbackBehavior(
       ConcurrencyMode = ConcurrencyMode.Single,
       UseSynchronizationContext = false)]
    public partial class MainForm : Form, IUserServiceCallback, IMessagingServiceCallback
    {
        /// <summary>
        /// The ui sync context.
        /// </summary>
        private readonly SynchronizationContext uiSyncContext;

        /// <summary>
        /// The current session.
        /// </summary>
        private Session currentSession;
        
        /// <summary>
        /// The <see cref="UserServiceClient"/> proxy.
        /// </summary>
        private UserServiceClient userProxy;

        /// <summary>
        /// The <see cref="MessagingServiceClient"/> proxy.
        /// </summary>
        private MessagingServiceClient messagingProxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.JoinedUsers = new BindingList<User>();

            this.ConnectedUsersDataGridView.DataSource = this.JoinedUsers;
            this.userProxy = new UserServiceClient(new InstanceContext(this));
            this.userProxy.Open();
            this.messagingProxy = new MessagingServiceClient(new InstanceContext(this));
            this.messagingProxy.Open();

            this.userProxy.Subscribe();
            foreach (var u in this.userProxy.GetJoinedUsers())
            {
                this.JoinedUsers.Add(u);
            }

            this.uiSyncContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// Gets or sets the joined users.
        /// </summary>
        /// <value>
        /// The joined users.
        /// </value>
        private BindingList<User> JoinedUsers { get; set; }

        /// <summary>
        /// Notifies the user joined.
        /// </summary>
        /// <param name="user">The user.</param>
        public void NotifyUserJoined(User user)
        {
            SendOrPostCallback callback = state => this.AddUser(user);

            this.uiSyncContext.Post(callback, user);
        }

        /// <summary>
        /// Notifies the user left.
        /// </summary>
        /// <param name="user">The user.</param>
        public void NotifyUserLeft(User user)
        {
            SendOrPostCallback callback = state => this.RemoveUser(user);

            this.uiSyncContext.Post(callback, user);
        }

        /// <summary>
        /// Notifies the new message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void NotifyNewMessage(Domain.Message message)
        {
            SendOrPostCallback callback = state => this.AddHistoryMessage(message);

            this.uiSyncContext.Post(callback, message);
        }

        /// <summary>
        /// Joins the user.
        /// </summary>
        /// <param name="username">The username.</param>
        private void JoinUser(string username)
        {
            var user = new User
            {
                Name = username
            };

            this.currentSession = this.userProxy.Join(user);
        }

        /// <summary>
        /// Handles the Click event of the JoinButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void JoinButtonClick(object sender, EventArgs e)
        {
            this.JoinUser(this.UsernameTextBox.Text);

            this.UsernameTextBox.Enabled = false;
            this.JoinButton.Enabled = false;
            this.LeaveButton.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the LeaveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LeaveButtonClick(object sender, EventArgs e)
        {
            this.userProxy.Leave(this.currentSession);
            this.currentSession = null;

            this.LeaveButton.Enabled = false;
            this.UsernameTextBox.Enabled = true;
            this.JoinButton.Enabled = true;
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="u">The u.</param>
        private void AddUser(User u)
        {
            this.JoinedUsers.Add(u);
            this.MessageHistoryTextBox.Text += string.Format("{0}\t{1} joined the conversation\r\n", DateTime.Now, u.Name);
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="u">The u.</param>
        private void RemoveUser(User u)
        {
            this.JoinedUsers.Remove(this.JoinedUsers.Single(ru => ru.Equals(u)));
            this.MessageHistoryTextBox.Text += string.Format("{0}\t{1} left the conversation\r\n", DateTime.Now, u.Name);
        }

        /// <summary>
        /// Handles the FormClosing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            this.userProxy.Unsubscribe();

            this.messagingProxy.Close();
            this.messagingProxy = null;
            this.userProxy.Close();
            this.userProxy = null;
        }

        /// <summary>
        /// Handles the Click event of the SendButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SendButtonClick(object sender, EventArgs e)
        {
            this.messagingProxy.Send(new Domain.Message { Payload = StringUtilities.StringToByteArray(this.MessageTextBox.Text) }, this.currentSession);
            this.MessageTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Adds the history message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void AddHistoryMessage(Domain.Message message)
        {
            this.MessageHistoryTextBox.Text += string.Format("{0}\t{1}\t{2}\r\n", DateTime.Now, message.Sender.Name, message.GetPayload());
        }
    }
}