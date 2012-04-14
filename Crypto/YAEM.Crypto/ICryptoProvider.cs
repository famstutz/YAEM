// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICryptoProvider.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Crypto
{
    /// <summary>
    /// Provides the necessary funcationalities to encrypt and decrypt messages.
    /// </summary>
    public interface ICryptoProvider
    {
        /// <summary>
        /// Gets or sets the initalization vector.
        /// </summary>
        /// <value>
        /// The initalization vector.
        /// </value>
        byte[] InitalizationVector { get;  set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        byte[] Key { get; set; }

        /// <summary>
        /// Encrypts the specified clear text.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <returns>The encrypted crypto text.</returns>
        byte[] Encrypt(string clearText);

        /// <summary>
        /// Decrypts the specified crypt text.
        /// </summary>
        /// <param name="cryptText">The crypt text.</param>
        /// <returns>The decrypted plain text.</returns>
        string Decrypt(byte[] cryptText);

        /// <summary>
        /// Gets the initialization vector.
        /// </summary>
        /// <returns>The initialization vector.</returns>
        byte[] GetInitializationVector();
    }
}
