﻿using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace YAEM.Crypto.Aes
{
    /// <summary>
    /// Implementation of a <see cref="ICryptoProvider"/> that uses the AES algorithm.
    /// </summary>
    [Export(typeof(ICryptoProvider))] 
    public class AesCryptoProvider : ICryptoProvider
    {
        private readonly AesCryptoServiceProvider aes;
        private readonly UTF8Encoding utf8;

        /// <summary>
        /// Gets or sets the crypto data.
        /// </summary>
        /// <value>
        /// The crypto data.
        /// </value>
        private ICryptoData CryptoData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AesCryptoProvider"/> class.
        /// </summary>
        /// <param name="cryptoData">The crypto data.</param>
        public AesCryptoProvider(ICryptoData cryptoData)
        {
            this.aes = new AesCryptoServiceProvider();
            this.utf8 = new UTF8Encoding();

            this.CryptoData = cryptoData;
        }

        /// <summary>
        /// Encrypts the specified crypto text.
        /// </summary>
        /// <param name="cryptoText">The crypto text.</param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] cryptoText)
        {
            return this.Transform(cryptoText, this.aes.CreateEncryptor(this.CryptoData.Key, this.CryptoData.InitalizationVector));
        }

        /// <summary>
        /// Encrypts the specified clear text.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <returns></returns>
        public string Encrypt(string clearText)
        {
            var input = utf8.GetBytes(clearText);
            var output = this.Encrypt(input);
            return Convert.ToBase64String(output);
        }

        /// <summary>
        /// Decrypts the specified crypto text.
        /// </summary>
        /// <param name="cryptoText">The crypto text.</param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] cryptoText)
        {
            return this.Transform(cryptoText, this.aes.CreateDecryptor(this.CryptoData.Key, this.CryptoData.InitalizationVector));
        }

        /// <summary>
        /// Decrypts the specified crypto text.
        /// </summary>
        /// <param name="cryptoText">The crypto text.</param>
        /// <returns></returns>
        public string Decrypt(string cryptoText)
        {
            var input = utf8.GetBytes(cryptoText);
            var output = this.Decrypt(input);
            return Convert.ToBase64String(output);
        }

        /// <summary>
        /// Transforms the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="cryptoTransform">The crypto transform.</param>
        /// <returns></returns>
        private byte[] Transform(byte[] input, ICryptoTransform cryptoTransform)
        {
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);

            cryptoStream.Write(input, 0, input.Length);
            cryptoStream.FlushFinalBlock();

            memoryStream.Position = 0;
            var result = new byte[memoryStream.Length - 1];
            memoryStream.Read(result, 0, result.Length);
            memoryStream.Close();
            cryptoStream.Close();

            return result;
        }
    }
}