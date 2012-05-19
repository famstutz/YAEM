// -----------------------------------------------------------------------
// <copyright file="Session.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace YAEM.Domain
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The session.
    /// </summary>
    [DataContract]
    public class Session : ObjectBase
    {
        /// <summary>
        /// The user.
        /// </summary>
        private User user;

        /// <summary>
        /// The expiry date.
        /// </summary>
        private DateTime expiryDate;

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        [DataMember]
        public User User
        {
            get
            { 
                return this.user;
            }

            set
            {
                this.user = value;
                this.NotifyPropertyChanged("User");
            }
        }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        /// <value>
        /// The expiry date.
        /// </value>
        [DataMember]
        public DateTime ExpiryDate
        {
            get
            {
                return this.expiryDate;
            }

            set
            {
                this.expiryDate = value;
                this.NotifyPropertyChanged("ExpiryDate");
            }
        }
    }
}
