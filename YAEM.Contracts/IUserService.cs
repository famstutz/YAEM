using YAEM.Domain;
using System.ServiceModel;

namespace YAEM.Contracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Session Register(User u);
        [OperationContract]
        void UnRegister(Session s);
        [OperationContract]
        bool IsRegistered(Session s);
    }
}
