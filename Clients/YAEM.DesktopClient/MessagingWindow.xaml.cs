using System;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Windows;
using YAEM.DesktopClient.Services;
using YAEM.Domain;
using System.Collections.ObjectModel;
using YAEM.Domain.Utilities;

namespace YAEM.DesktopClient
{
    /// <summary>
    /// Interaction logic for MessagingWindow.xaml
    /// </summary>
    public partial class MessagingWindow : IUserServiceCallback, IMessagingServiceCallback
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
        /// Initializes a new instance of the <see cref="MessagingWindow"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public MessagingWindow(string name)
        {
            InitializeComponent();

            this.JoinedUsers = new ObservableCollection<User>();

            this.userProxy = new UserServiceClient(new InstanceContext(this));
            this.userProxy.Open();
            this.messagingProxy = new MessagingServiceClient(new InstanceContext(this));
            this.messagingProxy.Open();

            this.userProxy.Subscribe();
            this.JoinUser(name);
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
        private ObservableCollection<User> JoinedUsers { get; set; }

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
        public void NotifyNewMessage(Message message)
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
        /// Leaves the user.
        /// </summary>
        private void LeaveUser()
        {
            this.userProxy.Leave(this.currentSession);
            this.currentSession = null;
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
        /// Adds the history message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void AddHistoryMessage(Message message)
        {
            this.MessageHistoryTextBox.Text += string.Format("{0}\t{1}\t{2}\r\n", DateTime.Now, message.Sender.Name, message.GetPayload());
        }

        /// <summary>
        /// Windows the closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.LeaveUser();
            this.userProxy.Unsubscribe();

            this.messagingProxy.Close();
            this.messagingProxy = null;
            this.userProxy.Close();
            this.userProxy = null;
        }

        /// <summary>
        /// Sends the button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void SendButtonClick(object sender, RoutedEventArgs e)
        {
            this.messagingProxy.Send(new Message { Payload = StringUtilities.StringToByteArray(this.MessageTextBox.Text) }, this.currentSession);
            this.MessageTextBox.Text = string.Empty;
        }
    }
}
