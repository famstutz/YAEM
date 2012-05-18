// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessagingServiceCallbackTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for IMessagingServiceCallbackTest and is intended to contain all IMessagingServiceCallbackTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.DesktopClient.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using YAEM.DesktopClient.Services;
    using YAEM.Domain;

    /// <summary>
    /// This is a test class for IMessagingServiceCallbackTest and is intended to contain all IMessagingServiceCallbackTest Unit Tests.
    /// </summary>
    [TestClass]
    public class IMessagingServiceCallbackTest
    {
        /// <summary>
        /// A test for NotifyNegotiateInitializationVector.
        /// </summary>
        [TestMethod]
        public void NotifyNegotiateInitializationVectorTest()
        {
            var mock = new Mock<IMessagingServiceCallback>();
            mock.Setup(x => x.NotifyNegotiateInitializationVector(new byte[] { 1, 2, 3 }, CryptoAlgorithm.Rijndael));
            var target = mock.Object;
            var initializationVector = new byte[] { 1, 2, 3 };
            var algorithm = CryptoAlgorithm.Rijndael;
            target.NotifyNegotiateInitializationVector(initializationVector, algorithm);
            mock.Verify(x => x.NotifyNegotiateInitializationVector(new byte[] { 1, 2, 3 }, CryptoAlgorithm.Rijndael));
        }

        /// <summary>
        /// A test for NotifyNegotiateKey.
        /// </summary>
        [TestMethod]
        public void NotifyNegotiateKeyTest()
        {
            var mock = new Mock<IMessagingServiceCallback>();
            mock.Setup(x => x.NotifyNegotiateKey(new byte[] { 1, 2, 3 }, CryptoAlgorithm.Rijndael));
            var target = mock.Object;
            var key = new byte[] { 1, 2, 3 };
            var algorithm = CryptoAlgorithm.Rijndael;
            target.NotifyNegotiateKey(key, algorithm);
            mock.Verify(x => x.NotifyNegotiateKey(new byte[] { 1, 2, 3 }, CryptoAlgorithm.Rijndael));
        }

        /// <summary>
        /// A test for NotifyNewMessage.
        /// </summary>
        [TestMethod]
        public void NotifyNewMessageTest()
        {
            var message = new Message
            {
                Algorithm = CryptoAlgorithm.None,
                Payload = new byte[] { 1, 2, 3 },
                Sender = new User { Name = "Florian" }
            };
            var mock = new Mock<IMessagingServiceCallback>();
            mock.Setup(x => x.NotifyNewMessage(message));
            var target = mock.Object;
            target.NotifyNewMessage(message);
            mock.Verify(x => x.NotifyNewMessage(message));
        }

        /// <summary>
        /// A test for NotifyUserJoined.
        /// </summary>
        [TestMethod]
        public void NotifyUserJoinedTest()
        {
            var user = new User { Name = "Florian" };
            var mock = new Mock<IMessagingServiceCallback>();
            mock.Setup(x => x.NotifyUserJoined(user));
            var target = mock.Object;
            target.NotifyUserJoined(user);
            mock.Verify(x => x.NotifyUserJoined(user));
        }

        /// <summary>
        /// A test for NotifyUserLeft.
        /// </summary>
        [TestMethod]
        public void NotifyUserLeftTest()
        {
            var user = new User { Name = "Florian" };
            var mock = new Mock<IMessagingServiceCallback>();
            mock.Setup(x => x.NotifyUserLeft(user));
            var target = mock.Object;
            target.NotifyUserLeft(user);
            mock.Verify(x => x.NotifyUserLeft(user));
        }
    }
}
