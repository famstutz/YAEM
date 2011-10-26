using YAEM.Domain;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;

namespace YAEM.Contracts
{
    [ServiceContract]
    public interface IMessagingService
    {
        [OperationContract]
        void Send(Message m, User reciever, Session sender);
        [OperationContract]
        void Send(Message m, IList<User> recievers, Session sender);
    }
}
