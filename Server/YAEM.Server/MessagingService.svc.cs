using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using YAEM.Contracts;
using YAEM.Domain;

namespace YAEM.Server
{
    public class MessagingService : IMessagingService
    {
        private IList<Message> _messageQueue = new List<Message>();

        public void Send(Domain.Message m, Domain.Session sender)
        {
            m.Sender = sender.User;
            _messageQueue.Add(m);
        }
    }
}
