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
    [ServiceBehavior(Namespace = "YAEM.Server.Services",
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
        /// Initialises a new instance of the <see cref="Services"/> class.
        /// </summary>
        public Services()
        {
            this.registeredSessions = new List<Session>();
            this.subscribers = new List<IServiceCallback>();
        }

        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user to be registered.</param>
        /// <returns>
        /// The registered session for the supplied user.
        /// </returns>
        public virtual Session Join(User user)
        {
            Logger.Instance.Info(string.Format("User <{0}> joined", user.Name));

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
        public virtual void Leave(Session session)
        {
            Logger.Instance.Info(string.Format("User <{0}> left", session.User.Name));

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
        public virtual bool IsJoined(Session s)
        {
            Logger.Instance.Info(string.Format("Called IsJoined with session key <{0}> for user <{1}>", s.Key, s.User.Name));

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
        public virtual IEnumerable<User> GetJoinedUsers()
        {
            Logger.Instance.Info("Asked for all joined users");

            return (from s in this.registeredSessions.Select(s => s.User)
                    select s).AsEnumerable<User>();
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sender">The sender.</param>
        public virtual void Send(Message message, Session sender)
        {
            Logger.Instance.Info(string.Format("User <{0}> sent message <{1}>", sender.User.Name, message.Payload));

            message.Sender = sender.User;

            this.subscribers.ForEach(callback => callback.NotifyNewMessage(message));
        }

        /// <summary>
        /// Negotiates the initialization vector.
        /// </summary>
        /// <param name="initializationVector">The initializatino vector.</param>
        /// <param name="algorithm">The algorithm.</param>
        public virtual void NegotiateInitializationVector(byte[] initializationVector, CryptoAlgorithm algorithm)
        {
            Logger.Instance.Info(string.Format("Initialization vector for crypto algorithm <{0}> sent", algorithm));

            this.subscribers.ForEach(callback => callback.NotifyNegotiateInitializationVector(initializationVector, algorithm));
        }

        /// <summary>
        /// Negotiates the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="algorithm">The algorithm.</param>
        public virtual void NegotiateKey(byte[] key, CryptoAlgorithm algorithm)
        {
            Logger.Instance.Info(string.Format("Key for crypto algorithm <{0}> sent", algorithm));

            this.subscribers.ForEach(callback => callback.NotifyNegotiateKey(key, algorithm));
        }

        /// <summary>
        /// Subscribes this instance.
        /// </summary>
        public virtual void Subscribe()
        {
            Logger.Instance.Info("Client subscribed");

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
        public virtual void Unsubscribe()
        {
            Logger.Instance.Info("Client unsubscribed");

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