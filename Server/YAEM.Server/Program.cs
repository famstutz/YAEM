using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace YAEM.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceHost(typeof(Services));
            services.Open();

            Logger.Instance.Info("Service is host at " + DateTime.Now.ToString(CultureInfo.InvariantCulture));
            Logger.Instance.Info("Host is running... Press <Enter> key to stop");
            Console.ReadLine();

            services.Close();
        }
    }
}
