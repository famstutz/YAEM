using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using YAEM.Contracts;
using YAEM.Domain;
using System.Collections;

namespace YAEM.Server
{
    public class UserService : IUserService
    {
        private IList<Session> _registeredSessions = new List<Session>();

        public Domain.Session Register(Domain.User u)
        {
            if (u == null)
                throw new ArgumentNullException("No User has been provided.");
            if (String.IsNullOrWhiteSpace(u.Name))
                throw new ArgumentOutOfRangeException("Username is empty or invalid.");
            var sessions = from rs in _registeredSessions
                           where rs.User == u
                           select rs;
            if (sessions.Count() > 0)
                throw new InvalidOperationException(String.Format("User '{0}' is already registered.", u.Name));

            var s = new Session()
            {
                User = u,
                SessionKey = Guid.NewGuid(),
                ExpiryDate = DateTime.Now.AddHours(1)
            };
            _registeredSessions.Add(s);
            return s;
        }

        public void UnRegister(Domain.Session s)
        {
            if (s == null)
                throw new ArgumentNullException("No Session has been provided.");
            if (s.ExpiryDate == default(DateTime))
                throw new ArgumentOutOfRangeException("ExpiryDate is null.");
            if (s.SessionKey == default(Guid))
                throw new ArgumentOutOfRangeException("SessionKey is null.");
            if (s.User == null)
                throw new ArgumentOutOfRangeException("User is null");
            var sessions = from rs in _registeredSessions
                           where rs == s
                           select rs;
            if (sessions.Count() == 0)
                throw new InvalidOperationException("Session is not registered.");

            _registeredSessions.Remove(s);
        }


        public bool IsRegistered(Session s)
        {
            if (s == null)
                return false;

            var sessions = from rs in _registeredSessions
                           where rs == s
                           select rs;
            if (sessions.Count() > 0)
                return true;
            return false;
        }
    }
}
