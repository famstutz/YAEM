// -----------------------------------------------------------------------
// <copyright file="Logger.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace YAEM.Server
{
    using log4net;
    using log4net.Config;
    
    /// <summary>
    /// The logger.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Initializes static members of the <see cref="Logger"/> class.
        /// </summary>
        static Logger()
        {
            Instance = LogManager.GetLogger("Default");
            BasicConfigurator.Configure();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static ILog Instance { get; private set; }
    }
}