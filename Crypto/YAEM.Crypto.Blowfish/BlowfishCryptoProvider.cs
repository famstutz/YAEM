// -----------------------------------------------------------------------
// <copyright file="BlowfishCryptoProvider.cs" company="ERNI Consulting AG">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.Composition;
using BlowFishCS;
using YAEM.Domain;

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
    [CryptoAlgorithm(Algorithm = CryptoAlgorithm.Blowfish)]
    public class BlowfishCryptoProvider : ICryptoProvider
    {
        private BlowFish blowFish;

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

        private BlowFish BlowFish
        {
            get
            {
                if (this.blowFish == null)
                {
                    this.blowFish = new BlowFish(this.Key)
                                        {
                                            IV = this.InitalizationVector
                                        };
                }
                return this.blowFish;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BlowfishCryptoProvider"/> class.
        /// </summary>
        [ImportingConstructor]
        public BlowfishCryptoProvider()
        {
            
        }

        public byte[] Encrypt(byte[] clearText)
        {
            return this.BlowFish.Encrypt_CBC(clearText);
        }

        public string Encrypt(string clearText)
        {
            return this.BlowFish.Encrypt_CBC(clearText);
        }

        public byte[] Decrypt(byte[] cryptoText)
        {
            return this.BlowFish.Decrypt_CBC(cryptoText);
        }

        public string Decrypt(string cryptText)
        {
            return this.BlowFish.Decrypt_CBC(cryptText);
        }
    }
}
