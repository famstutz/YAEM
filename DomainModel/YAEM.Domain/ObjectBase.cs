// -----------------------------------------------------------------------
// <copyright file="ObjectBase.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace YAEM.Domain
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;

    /// <summary>
    /// The object base.
    /// </summary>
    [DataContract]
    public abstract class ObjectBase : INotifyPropertyChanged
    {
        /// <summary>
        /// The key.
        /// </summary>
        private Guid key;

        /// <summary>
        /// Initialises a new instance of the <see cref="ObjectBase"/> class.
        /// </summary>
        protected ObjectBase()
        {
            this.key = Guid.NewGuid();
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the key.
        /// </summary>
        [DataMember]
        public Guid Key
        {
            get 
            { 
                return this.key;
            }

            private set
            {
                this.key = value;
                this.NotifyPropertyChanged("Key");
            }
        }

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="name">The name.</param>
        internal void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
