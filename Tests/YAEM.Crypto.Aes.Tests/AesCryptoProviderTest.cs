// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AesCryptoProviderTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for AesCryptoProviderTest and is intended to contain all AesCryptoProviderTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Crypto.Aes.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for AesCryptoProviderTest and is intended to contain all AesCryptoProviderTest Unit Tests.
    /// </summary>
    [TestClass]
    public class AesCryptoProviderTest
    {
        /// <summary>
        /// The key.
        /// </summary>
        private static readonly byte[] Key = new byte[] { 240, 186, 146, 67, 254, 199, 156, 209, 229, 139, 178, 46, 117, 248, 78, 27, 14, 130, 64, 110, 61, 111, 45, 200, 132, 99, 142, 169, 49, 255, 232, 9 };

        /// <summary>
        /// The Initialization Vector.
        /// </summary>
        private static readonly byte[] InitializationVector = new byte[] { 187, 226, 191, 10, 157, 102, 213, 204, 72, 145, 174, 33, 87, 44, 46, 108 };

        /// <summary>
        /// A test for Decrypt.
        /// </summary>
        [TestMethod]
        public void DecryptTest()
        {
            var target = new AesCryptoProvider() { Key = Key, InitalizationVector = InitializationVector};
            var cryptoText = new byte[] { 56, 148, 231, 102, 26, 238, 54, 45, 113, 205, 129, 41, 57, 221, 255, 130 };
            var expected = "Test";
            var actual = target.Decrypt(cryptoText);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Encrypt.
        /// </summary>
        [TestMethod]
        public void EncryptTest()
        {
            var target = new AesCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
            var clearText = "Test";
            var expected = new byte[] { 56, 148, 231, 102, 26, 238, 54, 45, 113, 205, 129, 41, 57, 221, 255, 130 };
            var actual = target.Encrypt(clearText);
            Assert.AreEqual(System.Convert.ToBase64String(expected), System.Convert.ToBase64String(actual));
        }

        /// <summary>
        /// A test for GetInitializationVector.
        /// </summary>
        [TestMethod]
        public void GetInitializationVectorTest()
        {
            var target = new AesCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
            var expected = typeof(byte[]);
            var actual = target.GetInitializationVector();
            Assert.IsInstanceOfType(actual, expected);
        }

        /// <summary>
        /// A test for InitalizationVector.
        /// </summary>
        [TestMethod]
        public void InitalizationVectorTest()
        {
            var target = new AesCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
            var initializiationVector = InitializationVector;
            target.InitalizationVector = initializiationVector;
            Assert.IsNotNull(target);
        }

        /// <summary>
        /// A test for Key.
        /// </summary>
        [TestMethod]
        public void KeyTest()
        {
            var target = new AesCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
            var key = Key;
            target.Key = key;
            Assert.IsNotNull(target);
        }
    }
}
