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
        void Send(Message m, Session sender);
    }
}
