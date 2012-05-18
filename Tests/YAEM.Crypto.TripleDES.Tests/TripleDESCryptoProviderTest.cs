// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TripleDESCryptoProviderTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for TripleDESCryptoProviderTest and is intended to contain all TripleDESCryptoProviderTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Crypto.TripleDES.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for TripleDESCryptoProviderTest and is intended to contain all TripleDESCryptoProviderTest Unit Tests.
    /// </summary>
    [TestClass]
    public class TripleDESCryptoProviderTest
    {
        /// <summary>
        /// The key.
        /// </summary>
        private static readonly byte[] Key = new byte[] { 41, 148, 67, 56, 177, 164, 82, 226, 67, 109, 85, 241, 143, 89, 93, 114, 230, 140, 143, 125, 16, 145, 208, 177 };

        /// <summary>
        /// The Initialization Vector.
        /// </summary>
        private static readonly byte[] InitializationVector = new byte[] { 90, 216, 132, 169, 243, 230, 190, 93 };

        /// <summary>
        /// A test for Decrypt.
        /// </summary>
        [TestMethod]
        public void DecryptTest()
        {
            var target = new TripleDESCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
            var cryptoText = new byte[] { 45, 52, 234, 74, 66, 9, 93, 149 };
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
            var target = new TripleDESCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
            var clearText = "Test";
            var expected = new byte[] { 45, 52, 234, 74, 66, 9, 93, 149 };
            var actual = target.Encrypt(clearText);
            Assert.AreEqual(System.Convert.ToBase64String(expected), System.Convert.ToBase64String(actual));
        }

        /// <summary>
        /// A test for GetInitializationVector.
        /// </summary>
        [TestMethod]
        public void GetInitializationVectorTest()
        {
            var target = new TripleDESCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
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
            var target = new TripleDESCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
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
            var target = new TripleDESCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
            var key = Key;
            target.Key = key;
            Assert.IsNotNull(target);
        }
    }
}
