using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using YAEM.Contracts;
using log4net;
using Microsoft.Practices.Unity;

namespace YAEM.Server
{
    class Program
    {
        static void Main(string[] args)
        {           
            UnityContainer container = new UnityContainer();

            container.RegisterInstance<ILog>(LogManager.GetLogger("YAEM.Server"));

            container.Resolve<ILog>().Info("Initializing Service...");

            try
            {
                // The service configuration is loaded from app.config
                IUserService userService = new UserService(container);
                using (ServiceHost host = new ServiceHost(userService))
                {
                    host.Open();

                    container.Resolve<ILog>().Info("Service is ready for requests. Press any key to close service.");
                    Console.Read();

                    container.Resolve<ILog>().Info("Closing service...");
                }
            }
            catch (Exception ex)
            {
                container.Resolve<ILog>().Error(ex);
            }
            
        }
    }
}
