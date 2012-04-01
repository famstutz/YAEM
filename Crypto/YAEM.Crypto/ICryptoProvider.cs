﻿namespace YAEM.Crypto
{
    /// <summary>
    /// Provides the necessary funcationalities to encrypt and decrypt messages.
    /// </summary>
    public interface ICryptoProvider
    {
        /// <summary>
        /// Encrypts the specified clear text.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <returns></returns>
        byte[] Encrypt(byte[] clearText);

        /// <summary>
        /// Encrypts the specified clear text.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <returns></returns>
        string Encrypt(string clearText);

        /// <summary>
        /// Decrypts the specified crypto text.
        /// </summary>
        /// <param name="cryptoText">The crypto text.</param>
        /// <returns></returns>
        byte[] Decrypt(byte[] cryptoText);

        /// <summary>
        /// Decrypts the specified crypt text.
        /// </summary>
        /// <param name="cryptText">The crypt text.</param>
        /// <returns></returns>
        string Decrypt(string cryptText);
    }
}