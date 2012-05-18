// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for UserTest and is intended to contain all UserTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for UserTest and is intended to contain all UserTest Unit Tests.
    /// </summary>
    [TestClass]
    public class UserTest
    {
        /// <summary>
        /// A test for User Constructor
        /// </summary>
        [TestMethod]
        public void UserConstructorTest()
        {
            var target = new User();
            Assert.IsNotNull(target);
        }

        /// <summary>
        /// A test for Equals
        /// </summary>
        [TestMethod]
        public void EqualsTest()
        {
            var target = new User { Name = "Florian" };
            var obj = new User { Name = "Florian" };
            var expected = false; // The Key is never the same
            var actual = target.Equals(obj);
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        /// A test for GetHashCode.
        /// </summary>
        [TestMethod]
        public void GetHashCodeTest()
        {
            var target = new User { Name = "Florian" };
            var expected = -1103750738;
            var actual = target.GetHashCode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for ToString.
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            var target = new User { Name = "Florian" };
            var expected = "Florian";
            var actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Name.
        /// </summary>
        [TestMethod]
        public void NameTest()
        {
            var target = new User { Name = "Florian" };
            var expected = "Florian";
            target.Name = expected;
            string actual = target.Name;
            Assert.AreEqual(expected, actual);
        }
    }
}
