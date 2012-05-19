// -----------------------------------------------------------------------
// <copyright file="CryptoAlgorithm.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace YAEM.Domain
{
    /// <summary>
    /// The crypto algorithm.
    /// </summary>
    public enum CryptoAlgorithm
    {
        /// <summary>
        /// No algorithm.
        /// </summary>
        None,

        /// <summary>
        /// Aes algorithm.
        /// </summary>
        Aes,

        /// <summary>
        /// Rijndael algorithm.
        /// </summary>
        Rijndael,

        /// <summary>
        /// TripleDES algorithm.
        /// </summary>
        TripleDES
    }
}
