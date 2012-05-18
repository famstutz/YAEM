// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessagingServiceTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for IMessagingServiceTest and is intended to contain all IMessagingServiceTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Contracts.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using YAEM.Contracts;
    using YAEM.Domain;

    /// <summary>
    /// This is a test class for IMessagingServiceTest and is intended to contain all IMessagingServiceTest Unit Tests.
    /// </summary>
    [TestClass]
    public class IMessagingServiceTest
    {
        /// <summary>
        /// A test for NegotiateInitializationVector.
        /// </summary>
        [TestMethod]
        public void NegotiateInitializationVectorTest()
        {
            var mock = new Mock<IMessagingService>();
            mock.Setup(x => x.NegotiateInitializationVector(new byte[] { 1, 2, 3 }, CryptoAlgorithm.Aes));
            var target = mock.Object;
            var initializationVector = new byte[] { 1, 2, 3 };
            var algorithm = CryptoAlgorithm.Aes;
            target.NegotiateInitializationVector(initializationVector, algorithm);
            mock.Verify(x => x.NegotiateInitializationVector(new byte[] { 1, 2, 3 }, CryptoAlgorithm.Aes));
        }

        /// <summary>
        /// A test for NegotiateKey.
        /// </summary>
        [TestMethod]
        public void NegotiateKeyTest()
        {
            var mock = new Mock<IMessagingService>();
            mock.Setup(x => x.NegotiateKey(new byte[] { 1, 2, 3 }, CryptoAlgorithm.Aes));
            var target = mock.Object;
            var key = new byte[] { 1, 2, 3 };
            var algorithm = CryptoAlgorithm.Aes;
            target.NegotiateKey(key, algorithm);
            mock.Verify(x => x.NegotiateKey(new byte[] { 1, 2, 3 }, CryptoAlgorithm.Aes));
        }

        /// <summary>
        /// A test for Send.
        /// </summary>
        [TestMethod]
        public void SendTest()
        {
            var message = new Message
            {
                Algorithm = CryptoAlgorithm.None,
                Payload = new byte[] { 1, 2, 3 },
                Sender = new User { Name = "Florian" }
            };
            var session = new Session { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } };
            var mock = new Mock<IMessagingService>();
            mock.Setup(x => x.Send(message, session));
            var target = mock.Object;
            var sender = new Session { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } };
            target.Send(message, sender);
            mock.Verify(x => x.Send(message, sender));
        }
    }
}
