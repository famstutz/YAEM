// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for SessionTest and is intended to contain all SessionTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Domain.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for SessionTest and is intended to contain all SessionTest Unit Tests.
    /// </summary>
    [TestClass]
    public class SessionTest
    {
        /// <summary>
        /// A test for Session Constructor.
        /// </summary>
        [TestMethod]
        public void SessionConstructorTest()
        {
            var target = new Session();
            Assert.IsNotNull(target);
        }

        /// <summary>
        /// A test for ExpiryDate.
        /// </summary>
        [TestMethod]
        public void ExpiryDateTest()
        {
            var target = new Session
                { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } };
            var expected = DateTime.Today.AddDays(1);
            target.ExpiryDate = expected;
            var actual = target.ExpiryDate;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for User.
        /// </summary>
        [TestMethod]
        public void UserTest()
        {
            var target = new Session
                { ExpiryDate = DateTime.Today.AddDays(1), User = new User { Name = "Florian" } };
            var expected = new User { Name = "Florian" };
            target.User = expected;
            var actual = target.User;
            Assert.AreEqual(expected, actual);
        }
    }
}
