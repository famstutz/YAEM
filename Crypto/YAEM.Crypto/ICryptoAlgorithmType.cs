// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICryptoAlgorithmType.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Crypto
{
    using YAEM.Domain;

    /// <summary>
    /// The crypto algorithm type.
    /// </summary>
    public interface ICryptoAlgorithmType
    {
        /// <summary>
        /// Gets the algorithm.
        /// </summary>
        CryptoAlgorithm Algorithm { get; }
    }
}
