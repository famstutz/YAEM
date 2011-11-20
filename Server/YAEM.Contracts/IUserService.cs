using YAEM.Domain;
using System.ServiceModel;
using System;
using System.Collections.Generic;

namespace YAEM.Contracts
{
    [ServiceContract(
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IUserServiceCallback))]
    public interface IUserService
    {
        [OperationContract]
        Session Register(User user);

        [OperationContract(IsOneWay = true)]
        void UnRegister(Session session);

        [OperationContract]
        bool IsRegistered(Session session);

        [OperationContract]
        IEnumerable<User> GetRegisteredUsers();
    }

    [ServiceContract]
    public interface IUserServiceCallback
    {
        [OperationContract(IsOneWay=true)]
        void NotifyUserRegistered(User user);

        [OperationContract(IsOneWay = true)]
        void NotifyUserUnRegistered(User user);
    }
}
