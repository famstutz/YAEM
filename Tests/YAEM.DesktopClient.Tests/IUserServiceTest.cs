// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserServiceTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for IUserServiceTest and is intended to contain all IUserServiceTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.DesktopClient.Tests
{
    using System;
    using System.Collections;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using YAEM.DesktopClient.Services;
    using YAEM.Domain;

    /// <summary>
    /// This is a test class for IUserServiceTest and is intended to contain all IUserServiceTest Unit Tests.
    /// </summary>
    [TestClass]
    public class IUserServiceTest
    {
        /// <summary>
        /// A test for GetJoinedUsers.
        /// </summary>
        [TestMethod]
        public void GetJoinedUsersTest()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(x => x.GetJoinedUsers()).Returns(
                new User[] { new User { Name = "Florian" }, new User { Name = "Brain" } });
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
            var mock = new Mock<IUserService>();
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
            var mock = new Mock<IUserService>();
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
            var mock = new Mock<IUserService>();
            mock.Setup(
                x => x.Leave(new Session { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } }));
            var target = mock.Object;
            var session = new Session { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } };
            target.Leave(session);
            Assert.IsFalse(target.IsJoined(session));
        }

        /// <summary>
        /// A test for Subscribe.
        /// </summary>
        [TestMethod]
        public void SubscribeTest()
        {
            var mock = new Mock<IUserService>();
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
            var mock = new Mock<IUserService>();
            mock.Setup(x => x.Unsubscribe());
            var target = mock.Object;
            target.Unsubscribe();
            mock.Verify(x => x.Unsubscribe());
        }
    }
}
