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
        /// Gets the payload.
        /// </summary>
        /// <returns>The payload as a string.</returns>
        public string GetPayload()
        {
            return StringUtilities.ByteArrayToString(this.Payload);
        }
    }
}
