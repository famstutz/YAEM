// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for MessageTest and is intended to contain all MessageTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for MessageTest and is intended to contain all MessageTest Unit Tests.
    /// </summary>
    [TestClass]
    public class MessageTest
    {
        /// <summary>
        /// A test for Message Constructor.
        /// </summary>
        [TestMethod]
        public void MessageConstructorTest()
        {
            var target = new Message();
            Assert.IsNotNull(target);
        }

        /// <summary>
        /// A test for GetPayload.
        /// </summary>
        [TestMethod]
        public void GetPayloadTest()
        {
            var target = new Message
                {
                    Algorithm = CryptoAlgorithm.None,
                    Payload = new byte[] { 84, 0, 101, 0, 115, 0, 116, 0 },
                    Sender = new User { Name = "Florian" }
                };
            var expected = "Test";
            var actual = target.GetPayload();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for SetPayload.
        /// </summary>
        [TestMethod]
        public void SetPayloadTest()
        {
            var target = new Message { Algorithm = CryptoAlgorithm.None, Sender = new User { Name = "Florian" } };
            var expected = "Test";
            var value = "Test";
            target.SetPayload(value);
            var actual = target.GetPayload();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Algorithm.
        /// </summary>
        [TestMethod]
        public void AlgorithmTest()
        {
            var target = new Message
                { Payload = new byte[] { 84, 0, 101, 0, 115, 0, 116, 0 }, Sender = new User { Name = "Florian" } };
            var expected = CryptoAlgorithm.Rijndael;
            target.Algorithm = expected;
            var actual = target.Algorithm;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Payload.
        /// </summary>
        [TestMethod]
        public void PayloadTest()
        {
            var target = new Message { Algorithm = CryptoAlgorithm.None, Sender = new User { Name = "Florian" } };
            var expected = new byte[] { 84, 0, 101, 0, 115, 0, 116, 0 };
            target.Payload = expected;
            var actual = target.Payload;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Sender.
        /// </summary>
        [TestMethod]
        public void SenderTest()
        {
            var target = new Message
                { Algorithm = CryptoAlgorithm.None, Payload = new byte[] { 84, 0, 101, 0, 115, 0, 116, 0 } };
            var expected = new User { Name = "Florian" };
            target.Sender = expected;
            var actual = target.Sender;
            Assert.AreEqual(expected, actual);
        }
    }
}
