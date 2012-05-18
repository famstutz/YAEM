// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICryptoAlgorithmTypeTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for ICryptoAlgorithmTypeTest and is intended to contain all ICryptoAlgorithmTypeTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Crypto.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using YAEM.Domain;

    /// <summary>
    /// This is a test class for ICryptoAlgorithmTypeTest and is intended to contain all ICryptoAlgorithmTypeTest Unit Tests.
    /// </summary>
    [TestClass]
    public class ICryptoAlgorithmTypeTest
    {
        /// <summary>
        /// A test for Algorithm.
        /// </summary>
        [TestMethod]
        public void AlgorithmTest()
        {
            var mock = new Mock<ICryptoAlgorithmType>();
            mock.SetupGet(x => x.Algorithm).Returns(CryptoAlgorithm.TripleDES);
            var target = mock.Object;
            var actual = target.Algorithm;
            Assert.IsNotNull(actual);
        }
    }
}
