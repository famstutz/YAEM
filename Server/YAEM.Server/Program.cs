// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Server
{
    using System;
    using System.Globalization;
    using System.ServiceModel;

    /// <summary>
    /// The program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Mains the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
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
