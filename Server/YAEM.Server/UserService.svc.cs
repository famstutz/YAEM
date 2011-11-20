using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using YAEM.Contracts;
using YAEM.Domain;
using System.Collections;
using Microsoft.Practices.Unity;
using log4net;

namespace YAEM.Server
{
    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single)]
    public class UserService : IUserService
    {
        private List<Session> registeredSessions;
        private List<IUserServiceCallback> callbackList;
        private IUnityContainer container;

        public UserService(IUnityContainer container)
        {
            this.container = container;
            this.registeredSessions = new List<Session>();
            this.callbackList = new List<IUserServiceCallback>();
        }

        public Domain.Session Register(Domain.User u)
        {
            container.Resolve<ILog>().Info("Register called");

            if (u == null)
                throw new ArgumentNullException("No User has been provided.");
            if (String.IsNullOrWhiteSpace(u.Name))
                throw new ArgumentOutOfRangeException("Username is empty or invalid.");
            var sessions = from rs in registeredSessions
                           where rs.User == u
                           select rs;
            if (sessions.Count() > 0)
                throw new InvalidOperationException(String.Format("User '{0}' is already registered.", u.Name));

            var s = new Session()
             {
                 User = u,
                 ExpiryDate = DateTime.Now.AddHours(1)
             };
            registeredSessions.Add(s);

            var userCallback = OperationContext.Current.GetCallbackChannel<IUserServiceCallback>();
            if (!callbackList.Contains(userCallback))
            {
                callbackList.Add(userCallback);
            }
            callbackList.ForEach(
                delegate(IUserServiceCallback callback)
                {
                    callback.NotifyUserRegistered(u);
                }
            );

            return s;
        }

        public void UnRegister(Domain.Session s)
        {
            container.Resolve<ILog>().Info("UnRegister called");

            if (s == null)
                throw new ArgumentNullException("No Session has been provided.");
            if (s.ExpiryDate == default(DateTime))
                throw new ArgumentOutOfRangeException("ExpiryDate is null.");
            if (s.User == null)
                throw new ArgumentOutOfRangeException("User is null");
            var sessions = from rs in registeredSessions
                           where rs.Key.Equals(s.Key)
                           select rs;
            if (sessions.Count() == 0)
                throw new InvalidOperationException("Session is not registered.");

            registeredSessions.Remove(sessions.SingleOrDefault());

            var userCallback = OperationContext.Current.GetCallbackChannel<IUserServiceCallback>();
            if (!callbackList.Contains(userCallback))
            {
                callbackList.Add(userCallback);
            }
            callbackList.ForEach(
                delegate(IUserServiceCallback callback)
                {
                    callback.NotifyUserUnRegistered(s.User);
                }
            );
        }

        public bool IsRegistered(Session s)
        {
            container.Resolve<ILog>().Info("IsRegistered called");

            if (s == null)
                return false;

            var sessions = from rs in registeredSessions
                           where rs.Key.Equals(s.Key)
                           select rs;
            if (sessions.Count() > 0)
                return true;
            return false;
        }


        public IEnumerable<User> GetRegisteredUsers()
        {
            container.Resolve<ILog>().Info("GetRegisteredUsers called");

            return (from s in registeredSessions.Select(s => s.User)
                        select s).AsEnumerable<User>();
        }
    }
}
