// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICryptoProviderTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for ICryptoProviderTest and is intended to contain all ICryptoProviderTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Crypto.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// This is a test class for ICryptoProviderTest and is intended to contain all ICryptoProviderTest Unit Tests.
    /// </summary>
    [TestClass]
    public class ICryptoProviderTest
    {
        /// <summary>
        /// A test for Decrypt.
        /// </summary>
        [TestMethod]
        public void DecryptTest()
        {
            var mock = new Mock<ICryptoProvider>();
            mock.Setup(x => x.Decrypt(new byte[] { 1, 2, 3 })).Returns("Test");
            var target = mock.Object;
            var cryptText = new byte[] { 1, 2, 3 };
            var expected = "Test";
            var actual = target.Decrypt(cryptText);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Encrypt.
        /// </summary>
        [TestMethod]
        public void EncryptTest()
        {
            var mock = new Mock<ICryptoProvider>();
            mock.Setup(x => x.Encrypt("Test")).Returns(new byte[] { 1,2,3});
            var target = mock.Object;
            var clearText = "Test";
            var expected = new byte[] { 1, 2, 3 };
            var actual = target.Encrypt(clearText);
            Assert.AreEqual(System.Convert.ToBase64String(expected), System.Convert.ToBase64String(actual));
        }

        /// <summary>
        /// A test for GetInitializationVector.
        /// </summary>
        [TestMethod]
        public void GetInitializationVectorTest()
        {
            var mock = new Mock<ICryptoProvider>();
            mock.Setup(x => x.GetInitializationVector()).Returns(new byte[] { 1, 2, 3 });
            var target = mock.Object;
            var expected = new byte[] { 1, 2, 3 };
            var actual = target.GetInitializationVector();
            Assert.AreEqual(System.Convert.ToBase64String(expected), System.Convert.ToBase64String(actual));
        }

        /// <summary>
        /// A test for InitalizationVector.
        /// </summary>
        [TestMethod]
        public void InitalizationVectorTest()
        {
            var mock = new Mock<ICryptoProvider>();
            mock.SetupGet(x => x.InitalizationVector).Returns(new byte[] { 1, 2, 3 });
            var target = mock.Object;
            var expected = new byte[] { 1, 2, 3 };
            var actual = target.InitalizationVector;
            Assert.AreEqual(System.Convert.ToBase64String(expected), System.Convert.ToBase64String(actual));
        }

        /// <summary>
        /// A test for Key.
        /// </summary>
        [TestMethod]
        public void KeyTest()
        {
            var mock = new Mock<ICryptoProvider>();
            mock.SetupGet(x => x.Key).Returns(new byte[] { 1, 2, 3 });
            var target = mock.Object;
            var expected = new byte[] { 1, 2, 3 };
            var actual = target.Key;
            Assert.AreEqual(System.Convert.ToBase64String(expected), System.Convert.ToBase64String(actual));
        }
    }
}
