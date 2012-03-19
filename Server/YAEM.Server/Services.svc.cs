// -----------------------------------------------------------------------
// <copyright file="Services.svc.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace YAEM.Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using Contracts;
    using Domain;

    /// <summary>
    /// The services implementation class.
    /// </summary>
    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single)]
    public class Services : ServiceHost, IUserService, IMessagingService
    {
        /// <summary>
        /// Contains all registered sessions.
        /// </summary>
        private readonly List<Session> registeredSessions;

        /// <summary>
        /// Holds references to all callbacks.
        /// </summary>
        private readonly List<IServiceCallback> subscribers;

        /// <summary>
        /// Contains all messages during life time.
        /// </summary>
        private readonly List<Message> messageQueue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Services"/> class.
        /// </summary>
        public Services()
        {
            this.registeredSessions = new List<Session>();
            this.messageQueue = new List<Message>();
            this.subscribers = new List<IServiceCallback>();
        }

        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user to be registered.</param>
        /// <returns>
        /// The registered session for the supplied user.
        /// </returns>
        public Session Join(User user)
        {
            Logger.Instance.Info("Register called");

            var sessions = from rs in this.registeredSessions
                           where rs.User == user
                           select rs;
            if (sessions.Any())
            {
                throw new InvalidOperationException(string.Format("User '{0}' is already registered.", user.Name));
            }

            var s = new Session
                        {
                            User = user,
                            ExpiryDate = DateTime.Now.AddHours(1)
                        };
            this.registeredSessions.Add(s);

            this.subscribers.ForEach(callback => callback.NotifyUserJoined(user));

            return s;
        }

        /// <summary>
        /// Leaves the specified session.
        /// </summary>
        /// <param name="session">The session.</param>
        public void Leave(Session session)
        {
            Logger.Instance.Info("UnRegister called");

            var sessions = from rs in this.registeredSessions
                           where rs.Key.Equals(session.Key)
                           select rs;
            
            if (!sessions.Any())
            {
                throw new InvalidOperationException("Session is not registered.");
            }

            this.registeredSessions.Remove(sessions.SingleOrDefault());

            this.subscribers.ForEach(callback => callback.NotifyUserLeft(session.User));
        }

        /// <summary>
        /// Determines whether the specified session is registered.
        /// </summary>
        /// <param name="s">The session to be validated.</param>
        /// <returns>
        ///   <c>true</c> if the specified session is registered; otherwise, <c>false</c>.
        /// </returns>
        public bool IsJoined(Session s)
        {
            Logger.Instance.Info("IsRegistered called");

            if (s == null)
            {
                return false;
            }

            var sessions = from rs in this.registeredSessions
                           where rs.Key.Equals(s.Key)
                           select rs;
            if (sessions.Any())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the registered users.
        /// </summary>
        /// <returns>A list with alle registered users.</returns>
        public IEnumerable<User> GetJoinedUsers()
        {
            Logger.Instance.Info("GetRegisteredUsers called");

            return (from s in this.registeredSessions.Select(s => s.User)
                    select s).AsEnumerable<User>();
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sender">The sender.</param>
        public void Send(Message message, Session sender)
        {
            message.Sender = sender.User;
            this.messageQueue.Add(message);

            this.subscribers.ForEach(callback => callback.NotifyNewMessage(message));
        }

        /// <summary>
        /// Subscribes this instance.
        /// </summary>
        public void Subscribe()
        {
            try
            {
                var callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
                if (!this.subscribers.Contains(callback))
                {
                    this.subscribers.Add(callback);
                }
                    //// return true;
            }
// ReSharper disable EmptyGeneralCatchClause
            catch (Exception)
// ReSharper restore EmptyGeneralCatchClause
            {
                //// return false;
            }
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        public void Unsubscribe()
        {
            try
            {
                var callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
                if (this.subscribers.Contains(callback))
                {
                    this.subscribers.Remove(callback);
                }
                //// return true;
            }
// ReSharper disable EmptyGeneralCatchClause
            catch (Exception)
// ReSharper restore EmptyGeneralCatchClause
            {
                //// return false;
            }
        }
    }
}