using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace YAEM.Domain
{
    [DataContract]
    public abstract class ObjectBase : INotifyPropertyChanged
    {
        private Guid key;

        [DataMember]
        public Guid Key
        {
            get { return key; }
            private set
            {
                this.key = value;
                this.NotifyPropertyChanged("Key");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public ObjectBase()
        {
            this.key = Guid.NewGuid();
        }

        internal void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
