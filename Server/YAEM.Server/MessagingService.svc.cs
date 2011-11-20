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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MessagingService : IMessagingService
    {
        private List<Message> messageQueue;

        public MessagingService()
        {
            this.messageQueue = new List<Message>();
        }


        public void Send(Domain.Message m, Domain.Session sender)
        {
            m.Sender = sender.User;
            messageQueue.Add(m);
        }
    }
}