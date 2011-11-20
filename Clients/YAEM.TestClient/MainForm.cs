using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using YAEM.TestClient.Services;
using System.Threading;
using YAEM.Domain;

namespace YAEM.TestClient
{
    [CallbackBehavior(
       ConcurrencyMode = ConcurrencyMode.Single,
       UseSynchronizationContext = false)]
    public partial class MainForm : Form, IUserServiceCallback
    {
        public BindingList<User> RegisteredUsers { get; set; }
        private Session registeredSession;
        private SynchronizationContext uiSyncContext = null;
        private UserServiceClient proxy;

        public MainForm()
        {
            InitializeComponent();

            RegisteredUsers = new BindingList<User>();
            this.ConnectedUsersDataGridView.DataSource = RegisteredUsers;
            
            this.proxy = new UserServiceClient(new InstanceContext(this), "TcpBinding");
            this.proxy.Open();
            proxy.GetRegisteredUsers().ForEach(u => this.RegisteredUsers.Add(u));

                        uiSyncContext = SynchronizationContext.Current;

        }

        public void RegisterUser(string username)
        {
            var user = new User()
            {
                Name = username
            };

            registeredSession  = proxy.Register(user);
        }

        private void RegisterUserButton_Click(object sender, EventArgs e)
        {
            this.RegisterUser(UsernameTextBox.Text);
        }

        private void UnRegisterUserButton_Click(object sender, EventArgs e)
        {
            proxy.UnRegister(registeredSession);
            registeredSession = null;
        }

        private void AddRegisteredUser(User u)
        {
            this.RegisteredUsers.Add(u);
        }

        private void RemoveRegisteredUser(User u)
        {
            (from ru in RegisteredUsers
             where ru.Equals(u)
             select u).Single(user => this.RegisteredUsers.Remove(user));
        }


        public void NotifyUserRegistered(User user)
        {
            SendOrPostCallback callback =
                delegate(object state)
                { this.AddRegisteredUser(user); };
          
            uiSyncContext.Post(callback, user);
        }   


        public void NotifyUserUnRegistered(User user)
        {
            SendOrPostCallback callback =
               delegate(object state)
               { this.RemoveRegisteredUser(user); };

            uiSyncContext.Post(callback, user);
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.proxy.Close();
            this.proxy = null;
        }
    }
}