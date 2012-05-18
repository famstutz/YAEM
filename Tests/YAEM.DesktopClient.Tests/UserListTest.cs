// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserListTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for UserListTest and is intended to contain all UserListTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.DesktopClient.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for UserListTest and is intended to contain all UserListTest Unit Tests.
    /// </summary>
    [TestClass()]
    public class UserListTest
    {
        /// <summary>
        /// A test for UserList Constructor.
        /// </summary>
        [TestMethod]
        public void UserListConstructorTest()
        {
            var target = new UserList();
            Assert.IsNotNull(target);
        }
    }
}