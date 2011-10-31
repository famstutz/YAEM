using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using YAEM.Contracts;

namespace YAEM.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MessagingService" in code, svc and config file together.
    public class MessagingService : IMessagingService
    {
        public void Send(Domain.Message m, Domain.User reciever, Domain.Session sender)
        {
            throw new NotImplementedException();
        }

        public void Send(Domain.Message m, IList<Domain.User> recievers, Domain.Session sender)
        {
            throw new NotImplementedException();
        }
    }
}
