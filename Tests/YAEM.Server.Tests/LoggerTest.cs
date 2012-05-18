// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for LoggerTest and is intended to contain all LoggerTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Server.Tests
{
    using log4net;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for LoggerTest and is intended to contain all LoggerTest Unit Tests.
    /// </summary>
    [TestClass]
    public class LoggerTest
    {
        /// <summary>
        /// A test for Instance.
        /// </summary>
        [TestMethod]
        public void InstanceTest()
        {
            var actual = Logger.Instance;
            var expected = typeof(ILog);
            Assert.IsInstanceOfType(actual, expected);
        }
    }
}
