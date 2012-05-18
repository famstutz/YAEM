// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringUtilitiesTest.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   This is a test class for StringUtilitiesTest and is intended to contain all StringUtilitiesTest Unit Tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using YAEM.Domain.Utilities;

    /// <summary>
    /// This is a test class for StringUtilitiesTest and is intended to contain all StringUtilitiesTest Unit Tests.
    /// </summary>
    [TestClass]
    public class StringUtilitiesTest
    {
        /// <summary>
        /// A test for ByteArrayToString.
        /// </summary>
        [TestMethod]
        public void ByteArrayToStringTest()
        {
            var arr = new byte[] { 84, 0, 101, 0, 115, 0, 116, 0 };
            var expected = "Test";
            var actual = StringUtilities.ByteArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for StringToByteArray.
        /// </summary>
        [TestMethod]
        public void StringToByteArrayTest()
        {
            var str = "Test";
            var expected = new byte[] { 84, 0, 101, 0, 115, 0, 116, 0 };
            var actual = StringUtilities.StringToByteArray(str);
            Assert.AreEqual(System.Convert.ToBase64String(expected), System.Convert.ToBase64String(actual));
        }
    }
}
