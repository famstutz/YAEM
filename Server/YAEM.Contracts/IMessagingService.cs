using YAEM.Domain;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;

namespace YAEM.Contracts
{
    [ServiceContract(
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IMessagingServiceCallback))]
    public interface IMessagingService
    {
        [OperationContract(IsOneWay = true)]
        void Send(Message message, Session sender);
    }

    [ServiceContract]
    public interface IMessagingServiceCallback
    {

    }
}