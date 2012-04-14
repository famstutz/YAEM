// -----------------------------------------------------------------------
// <copyright file="CryptoAlgorithmAttribute.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace YAEM.Crypto
{
    using System;
    using System.ComponentModel.Composition;

    using YAEM.Domain;

    /// <summary>
    /// The crypto algorithm attribute.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CryptoAlgorithmAttribute : ExportAttribute
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CryptoAlgorithmAttribute"/> class. 
        /// </summary>
        public CryptoAlgorithmAttribute()
            : base(typeof(ICryptoProvider))
        {
        }

        /// <summary>
        /// Gets or sets the algorithm.
        /// </summary>
        /// <value>
        /// The algorithm.
        /// </value>
        public CryptoAlgorithm Algorithm { get; set; }
    }
}
