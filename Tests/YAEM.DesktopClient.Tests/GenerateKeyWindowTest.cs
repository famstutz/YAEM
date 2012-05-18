// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenerateKeyWindowTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for GenerateKeyWindowTest and is intended to contain all GenerateKeyWindowTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.DesktopClient.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for GenerateKeyWindowTest and is intended to contain all GenerateKeyWindowTest Unit Tests.
    /// </summary>
    [TestClass]
    public class GenerateKeyWindowTest
    {
        /// <summary>
        /// A test for GenerateKeyWindow Constructor.
        /// </summary>
        [TestMethod]
        public void GenerateKeyWindowConstructorTest()
        {
            var target = new GenerateKeyWindow();
            Assert.IsNotNull(target);
        }

        /// <summary>
        /// A test for InitializeComponent.
        /// </summary>
        [TestMethod]
        public void InitializeComponentTest()
        {
            var target = new GenerateKeyWindow(); 
            target.InitializeComponent();
            Assert.IsNotNull(target);
        }

        /// <summary>
        /// A test for Key.
        /// </summary>
        [TestMethod]
        public void KeyTest()
        {
            var target = new GenerateKeyWindow(); 
            string expected = string.Empty; 
            string actual;
            target.Key = expected;
            actual = target.Key;
            Assert.AreEqual(expected, actual);
        }
    }
}
