// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicesTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for ServicesTest and is intended to contain all ServicesTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Server.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using YAEM.Contracts;
    using YAEM.Domain;

    /// <summary>
    /// This is a test class for ServicesTest and is intended to contain all ServicesTest Unit Tests.
    /// </summary>
    [TestClass]
    public class ServicesTest
    {
        /// <summary>
        /// A test for Services Constructor.
        /// </summary>
        [TestMethod]
        public void ServicesConstructorTest()
        {
            var target = new Services();
            Assert.IsNotNull(target);
        }

        /// <summary>
        /// A test for GetJoinedUsers.
        /// </summary>
        [TestMethod]
        public void GetJoinedUsersTest()
        {
            var mock = new Mock<Services>();
            mock.Setup(x => x.GetJoinedUsers()).Returns(
                new List<User> { new User { Name = "Florian" }, new User { Name = "Brain" } });
            var expected = typeof(User);
            var target = mock.Object;
            var actual = target.GetJoinedUsers();
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)actual, expected);
        }

        /// <summary>
        /// A test for IsJoined.
        /// </summary>
        [TestMethod]
        public void IsJoinedTest()
        {
            var mock = new Mock<Services>();
            mock.Setup(
                x => x.IsJoined(new Session { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } }))
                .Returns(true);
            var s = new Session { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } };
            var expected = false; // The Key is never the same
            var target = mock.Object;
            var actual = target.IsJoined(s);
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        /// A test for Join.
        /// </summary>
        [TestMethod]
        public void JoinTest()
        {
            var user = new User { Name = "Florian" };
            var mock = new Mock<Services>();
            mock.Setup(x => x.Join(user)).Returns(
                new Session { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } });
            var target = mock.Object;
            var actual = target.Join(user);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        /// A test for Leave.
        /// </summary>
        [TestMethod]
        public void LeaveTest()
        {
            var mock = new Mock<Services>();
            mock.Setup(
                x => x.Leave(new Session { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } }));
            var target = mock.Object;
            var session = new Session { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } };
            target.Leave(session);
            Assert.IsFalse(target.IsJoined(session));
        }

        /// <summary>
        /// A test for NegotiateInitializationVector.
        /// </summary>
        [TestMethod]
        public void NegotiateInitializationVectorTest()
        {
            var mock = new Mock<Services>();
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
            var mock = new Mock<Services>();
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
            var mock = new Mock<Services>();
            mock.Setup(x => x.Send(message, session));
            var target = mock.Object;
            var sender = new Session { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } };
            target.Send(message, sender);
            mock.Verify(x => x.Send(message, sender));
        }

        /// <summary>
        /// A test for Subscribe.
        /// </summary>
        [TestMethod]
        public void SubscribeTest()
        {
            var mock = new Mock<Services>();
            mock.Setup(x => x.Subscribe());
            var target = mock.Object;
            target.Subscribe();
            mock.Verify(x => x.Subscribe());
        }

        /// <summary>
        /// A test for Unsubscribe.
        /// </summary>
        [TestMethod]
        public void UnsubscribeTest()
        {
            var mock = new Mock<Services>();
            mock.Setup(x => x.Unsubscribe());
            var target = mock.Object;
            target.Unsubscribe();
            mock.Verify(x => x.Unsubscribe());
        }
    }
}
