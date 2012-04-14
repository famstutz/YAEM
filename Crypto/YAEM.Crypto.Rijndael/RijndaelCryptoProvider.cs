// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RijndaelCryptoProvider.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.Crypto.Rijndael
{
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Security.Cryptography;

    using YAEM.Domain;

    /// <summary>
    /// Implementation of a <see cref="ICryptoProvider"/> that uses the Triple DES algorithm.
    /// </summary>
    [Export(typeof(ICryptoProvider))]
    [CryptoAlgorithm(Algorithm = CryptoAlgorithm.Rijndael)]
    public class RijndaelCryptoProvider : ICryptoProvider
    {
        /// <summary>
        /// Gets or sets the initalization vector.
        /// </summary>
        /// <value>
        /// The initalization vector.
        /// </value>
        public byte[] InitalizationVector { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public byte[] Key { get; set; }

        /// <summary>
        /// Encrypts the specified clear text.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <returns>
        /// The encrypted crypto text.
        /// </returns>
        public byte[] Encrypt(string clearText)
        {
            using (var rijndael = new RijndaelManaged())
            {
                rijndael.Key = this.Key;
                rijndael.IV = this.InitalizationVector;

                var encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(clearText);
                        }

                        return memoryStream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Decrypts the specified crypt text.
        /// </summary>
        /// <param name="cryptoText">The crypto text.</param>
        /// <returns>The plain text.</returns>
        public string Decrypt(byte[] cryptoText)
        {
            string clearText;

            using (var rijndael = new RijndaelManaged())
            {
                rijndael.Key = this.Key;
                rijndael.IV = this.InitalizationVector;

                var decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

                using (var memoryStream = new MemoryStream(cryptoText))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            clearText = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return clearText;
        }

        /// <summary>
        /// Gets the initialization vector.
        /// </summary>
        /// <returns>
        /// The initialization vector.
        /// </returns>
        public byte[] GetInitializationVector()
        {
            var rijndael = new RijndaelManaged();
            rijndael.GenerateIV();
            return rijndael.IV;
        }
    }
}
