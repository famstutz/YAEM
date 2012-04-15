// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessagingWindow.xaml.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.DesktopClient
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.ServiceModel;
    using System.Threading;
    using System.Windows;

    using YAEM.Crypto;
    using YAEM.DesktopClient.Services;
    using YAEM.Domain;
    using YAEM.Domain.Utilities;

    /// <summary>
    /// Interaction logic for MessagingWindow.xaml
    /// </summary>
    [CallbackBehavior(
       ConcurrencyMode = ConcurrencyMode.Single,
       UseSynchronizationContext = false)]
    public partial class MessagingWindow : INotifyPropertyChanged, IUserServiceCallback, IMessagingServiceCallback
    {
        /// <summary>
        /// The composition container.
        /// </summary>
        private readonly CompositionContainer compositionContainer;

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
        /// Initialises a new instance of the <see cref="MessagingWindow"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public MessagingWindow(string name)
        {
            InitializeComponent();

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog("..\\..\\Crypto", "*.dll"));
            var batch = new CompositionBatch();
            batch.AddPart(this);
            this.compositionContainer = new CompositionContainer(catalog);
            ////get all the exports and load them into the appropriate list tagged with the importmany
            this.compositionContainer.Compose(batch);

            this.CryptoAlgorithmComboBox.ItemsSource =
                (new List<CryptoAlgorithm> { CryptoAlgorithm.None }).Union(
                    this.CryptoProviders.Select(c => c.Metadata.Algorithm).Distinct()).ToList();

            this.userProxy = new UserServiceClient(new InstanceContext(this));
            this.userProxy.Open();
            this.messagingProxy = new MessagingServiceClient(new InstanceContext(this));
            this.messagingProxy.Open();

            this.userProxy.Subscribe();
            foreach (var u in this.userProxy.GetJoinedUsers())
            {
                this.AddUser(u);
            }

            this.uiSyncContext = SynchronizationContext.Current;
            
            this.JoinUser(name);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the <see cref="ICryptoProvider"/> crypto providers.
        /// </summary>
        /// <value>
        /// The crypto providers.
        /// </value>
        [ImportMany]
        private IEnumerable<Lazy<ICryptoProvider, ICryptoAlgorithmType>> CryptoProviders { get; set; }
        
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
        /// Notifies the negotiate initialization vector.
        /// </summary>
        /// <param name="initializationVector">The initialization vector.</param>
        /// <param name="algorithm">The algorithm.</param>
        public void NotifyNegotiateInitializationVector(byte[] initializationVector, CryptoAlgorithm algorithm)
        {
            var cp = this.GetCryptoProvider(algorithm);
            cp.InitalizationVector = initializationVector;
        }

        /// <summary>
        /// Notifies the negotiate key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="algorithm">The algorithm.</param>
        public void NotifyNegotiateKey(byte[] key, CryptoAlgorithm algorithm)
        {
            var cp = this.GetCryptoProvider(algorithm);
            cp.Key = key;
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Gets the crypto provider.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>The crypto provider.</returns>
        private ICryptoProvider GetCryptoProvider(CryptoAlgorithm algorithm)
        {
            return (from c in this.CryptoProviders where c.Metadata.Algorithm == algorithm select c.Value).FirstOrDefault();
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
            ((UserList)this.Resources["JoinedUsers"]).Add(u);
            this.MessageHistoryTextBox.Text += string.Format("{0}\t{1} joined the conversation\r\n", DateTime.Now, u.Name);
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="u">The u.</param>
        private void RemoveUser(User u)
        {
            var joinedUsers = (UserList)this.Resources["JoinedUsers"];
            joinedUsers.Remove(joinedUsers.Single(ru => ru.Equals(u)));
            this.MessageHistoryTextBox.Text += string.Format("{0}\t{1} left the conversation\r\n", DateTime.Now, u.Name);
        }

        /// <summary>
        /// Adds the history message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void AddHistoryMessage(Message message)
        {
            string payload;
            if (message.Algorithm == CryptoAlgorithm.None)
            {
                payload = message.GetPayload();
            }
            else
            {
                var cp = this.GetCryptoProvider(message.Algorithm);

                if (cp.InitalizationVector != null && cp.Key != null)
                {
                    payload = cp.Decrypt(message.Payload);
                }
                else
                {
                    payload = message.GetPayload();
                }
            }

            this.MessageHistoryTextBox.Text += string.Format("{0}\t{1}\t{2}\r\n", DateTime.Now, message.Sender.Name, payload);
        }

        /// <summary>
        /// Sends the button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void SendButtonClick(object sender, RoutedEventArgs e)
        {
            var algo = (CryptoAlgorithm)this.CryptoAlgorithmComboBox.SelectedValue;

            if (algo == CryptoAlgorithm.None)
            {
                var m = new Message();
                m.SetPayload(this.MessageTextBox.Text);
                this.messagingProxy.Send(
                    m,
                    this.currentSession);
            }
            else
            {
                var cp = this.GetCryptoProvider(algo);

                this.messagingProxy.Send(
                    new Message
                    {
                        Payload = cp.Encrypt(this.MessageTextBox.Text),
                        Algorithm = (CryptoAlgorithm)this.CryptoAlgorithmComboBox.SelectedValue
                    },
                    this.currentSession);
            }

            this.MessageTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Cryptoes the algorithm combo box selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void CryptoAlgorithmComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var algo = (CryptoAlgorithm)this.CryptoAlgorithmComboBox.SelectedValue;
            if (algo != CryptoAlgorithm.None && this.messagingProxy != null)
            {
                var cp = this.GetCryptoProvider(algo);
                if (cp.InitalizationVector == null)
                {
                    this.messagingProxy.NegotiateInitializationVector(cp.GetInitializationVector(), (CryptoAlgorithm)this.CryptoAlgorithmComboBox.SelectedValue);
                }

                if (cp.Key == null)
                {
                    var k = new GenerateKeyWindow();
                    k.ShowDialog();
                    this.messagingProxy.NegotiateKey(StringUtilities.StringToByteArray(k.Key), (CryptoAlgorithm)this.CryptoAlgorithmComboBox.SelectedValue);
                }
            }
        }

        /// <summary>
        /// Windows the closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void WindowClosed(object sender, EventArgs e)
        {
            this.LeaveUser();
            this.userProxy.Unsubscribe();

            this.messagingProxy.Close();
            this.messagingProxy = null;
            this.userProxy.Close();
            this.userProxy = null;
        }
    }
}