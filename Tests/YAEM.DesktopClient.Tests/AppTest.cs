// --------------------------------------------------------------------------------------------------------------------
// <copyright file=/// AppTest.cs///  company=/// Florian Amstutz/// >
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for AppTest and is intended to contain all AppTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.DesktopClient.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for AppTest and is intended to contain all AppTest Unit Tests.
    /// </summary>
    [TestClass]
    public class AppTest
    {
        /// <summary>
        /// A test for App Constructor.
        /// </summary>
        [TestMethod]
        public void AppConstructorTest()
        {
            var target = new App();
            Assert.IsNotNull(target);
        }
    }
}
