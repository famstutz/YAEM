// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CryptoAlgorithmAttributeTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   Defines the CryptoAlgorithmAttributeTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Crypto.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using YAEM.Crypto;
    using YAEM.Domain;

    /// <summary>
    /// This is a test class for CryptoAlgorithmAttributeTest and is intended to contain all CryptoAlgorithmAttributeTest Unit Tests.
    /// </summary>
    [TestClass]
    public class CryptoAlgorithmAttributeTest
    {
        /// <summary>
        /// A test for CryptoAlgorithmAttribute Constructor.
        /// </summary>
        [TestMethod]
        public void CryptoAlgorithmAttributeConstructorTest()
        {
            var target = new CryptoAlgorithmAttribute();
            Assert.IsNotNull(target);
        }

        /// <summary>
        /// A test for Algorithm.
        /// </summary>
        [TestMethod]
        public void AlgorithmTest()
        {
            var target = new CryptoAlgorithmAttribute() { Algorithm = CryptoAlgorithm.Aes };
            var expected = CryptoAlgorithm.Aes;
            target.Algorithm = expected;
            var actual = target.Algorithm;
            Assert.AreEqual(expected, actual);
        }
    }
}
