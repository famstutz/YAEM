// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectWindowTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for ConnectWindowTest and is intended to contain all ConnectWindowTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.DesktopClient.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for ConnectWindowTest and is intended to contain all ConnectWindowTest Unit Tests.
    /// </summary>
    [TestClass]
    public class ConnectWindowTest
    {
        /// <summary>
        /// A test for ConnectWindow Constructor.
        /// </summary>
        [TestMethod]
        public void ConnectWindowConstructorTest()
        {
            var target = new ConnectWindow();
            Assert.IsNotNull(target);
        }

        /// <summary>
        /// A test for InitializeComponent.
        /// </summary>
        [TestMethod]
        public void InitializeComponentTest()
        {
            var target = new ConnectWindow();
            target.InitializeComponent();
            Assert.IsNotNull(target);
        }
    }
}
