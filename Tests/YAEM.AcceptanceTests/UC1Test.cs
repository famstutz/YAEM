﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UC1Test.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// <summary>
//   The UC1Test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.AcceptanceTests
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The UC1Test.
    /// </summary>
    [CodedUITest]
    public class UC1Test
    {
        /// <summary>
        /// The UIMap.
        /// </summary>
        private UIMap map;

        /// <summary>
        /// The Server.
        /// </summary>
        private ApplicationUnderTest server;

        /// <summary>
        /// The Client.
        /// </summary>
        private ApplicationUnderTest client;

        /// <summary>
        /// Gets the UI map.
        /// </summary>
        private UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        /// <summary>
        /// Joins this instance.
        /// </summary>
        [TestMethod]
        public void Join()
        {
            this.UIMap.Join();
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.server = ApplicationUnderTest.Launch(Path.Combine(Directory.GetCurrentDirectory(), "YAEM.Server.exe"));
            this.client = ApplicationUnderTest.Launch(Path.Combine(Directory.GetCurrentDirectory(), "YAEM.DesktopClient.exe"));
        }

        /// <summary>
        /// Tests the cleanup.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            this.client.Close();
            this.server.Close();
        }
    }
}
