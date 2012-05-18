// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RijndaelCryptoProviderTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for RijndaelCryptoProviderTest and is intended to contain all RijndaelCryptoProviderTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Crypto.Rijndael.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for RijndaelCryptoProviderTest and is intended to contain all RijndaelCryptoProviderTest Unit Tests.
    /// </summary>
    [TestClass]
    public class RijndaelCryptoProviderTest
    {
        /// <summary>
        /// The key.
        /// </summary>
        private static readonly byte[] Key = new byte[] { 14, 66, 51, 2, 141, 176, 163, 110, 89, 27, 43, 149, 65, 78, 160, 104, 206, 198, 38, 20, 23, 206, 112, 135, 76, 93, 140, 84, 103, 128, 87, 45 };

        /// <summary>
        /// The Initialization Vector.
        /// </summary>
        private static readonly byte[] InitializationVector = new byte[] { 151, 51, 155, 163, 69, 168, 207, 31, 50, 142, 54, 76, 120, 34, 253, 156 };

        /// <summary>
        /// A test for Decrypt.
        /// </summary>
        [TestMethod]
        public void DecryptTest()
        {
            var target = new RijndaelCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
            var cryptoText = new byte[] { 92, 88, 212, 96, 182, 215, 173, 130, 236, 184, 241, 111, 218, 2, 147, 142 };
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
            var target = new RijndaelCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
            var clearText = "Test";
            var expected = new byte[] { 92, 88, 212, 96, 182, 215, 173, 130, 236, 184, 241, 111, 218, 2, 147, 142 };
            var actual = target.Encrypt(clearText);
            Assert.AreEqual(System.Convert.ToBase64String(expected), System.Convert.ToBase64String(actual));
        }

        /// <summary>
        /// A test for GetInitializationVector.
        /// </summary>
        [TestMethod]
        public void GetInitializationVectorTest()
        {
            var target = new RijndaelCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
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
            var target = new RijndaelCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
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
            var target = new RijndaelCryptoProvider() { Key = Key, InitalizationVector = InitializationVector };
            var key = Key;
            target.Key = key;
            Assert.IsNotNull(target);
        }
    }
}
