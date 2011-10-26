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
    public class UserService : IUserService
    {
        public Domain.Session Register(Domain.User u)
        {
            var s = new Session()
            {
                User = u,
                SessionKey = new Guid(),
                ExpiryDate = DateTime.Now.AddHours(1)
            };
            return s;
        }

        public void UnRegister(Domain.Session s)
        {
            throw new NotImplementedException();
        }
    }
}
