// -----------------------------------------------------------------------
// <copyright file="Message.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace YAEM.Domain
{
    using System.Runtime.Serialization;
    using Utilities;

    /// <summary>
    /// The message.
    /// </summary>
    [DataContract]
    public class Message : ObjectBase
    {
        /// <summary>
        /// The user.
        /// </summary>
        private User sender;

        /// <summary>
        /// The payload.
        /// </summary>
        private byte[] payload;

        /// <summary>
        /// The crypto algorithm.
        /// </summary>
        private CryptoAlgorithm algorithm;

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        [DataMember]
        public User Sender
        {
            get
            {
                return this.sender;
            }

            set
            {
                this.sender = value;
                this.NotifyPropertyChanged("Sender");
            }
        }

        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        /// <value>
        /// The payload.
        /// </value>
        [DataMember]
        public byte[] Payload
        {
            get
            {
                return this.payload;
            }

            set
            {
                this.payload = value;
                this.NotifyPropertyChanged("Payload");
            }
        }
        
        /// <summary>
        /// Gets or sets the crypto algorithm.
        /// </summary>
        /// <value>
        /// The crypto algorithm.
        /// </value>
        [DataMember]
        public CryptoAlgorithm Algorithm
        {
            get
            {
                return this.algorithm;
            }

            set
            {
                this.algorithm = value;
                this.NotifyPropertyChanged("Algorithm");
            }
        }

        /// <summary>
        /// Gets the payload.
        /// </summary>
        /// <returns>The payload.</returns>
        public string GetPayload()
        {
            return StringUtilities.ByteArrayToString(this.Payload);
        }

        /// <summary>
        /// Sets the payload.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetPayload(string value)
        {
            this.Payload = StringUtilities.StringToByteArray(value);
        }
     }
}
