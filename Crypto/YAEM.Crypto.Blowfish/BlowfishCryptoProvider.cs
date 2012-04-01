// -----------------------------------------------------------------------
// <copyright file="BlowfishCryptoProvider.cs" company="ERNI Consulting AG">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.Composition;
using BlowFishCS;

namespace YAEM.Crypto.Blowfish
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Export(typeof(ICryptoProvider))] 
    public class BlowfishCryptoProvider : ICryptoProvider
    {
        private readonly BlowFish blowFish;

        /// <summary>
        /// Gets or sets the crypto data.
        /// </summary>
        /// <value>
        /// The crypto data.
        /// </value>
        private ICryptoData CryptoData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlowfishCryptoProvider"/> class.
        /// </summary>
        /// <param name="cryptoData">The crypto data.</param>
        public BlowfishCryptoProvider(ICryptoData cryptoData)
        {
            this.CryptoData = cryptoData;

            this.blowFish = new BlowFish(this.CryptoData.Key)
                                {
                                    IV = this.CryptoData.InitalizationVector
                                };
        }

        public byte[] Encrypt(byte[] clearText)
        {
            return this.blowFish.Encrypt_CBC(clearText);
        }

        public string Encrypt(string clearText)
        {
            return this.blowFish.Encrypt_CBC(clearText);
        }

        public byte[] Decrypt(byte[] cryptoText)
        {
            return this.blowFish.Decrypt_CBC(cryptoText);
        }

        public string Decrypt(string cryptText)
        {
            return this.blowFish.Decrypt_CBC(cryptText);
        }
    }
}
