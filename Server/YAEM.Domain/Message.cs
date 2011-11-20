using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace YAEM.Domain
{
    [DataContract]
    public class Message : ObjectBase
    {
        private User sender;
        private IList<User> recievers;
        private byte[] payload;

        [DataMember]
        public User Sender
        {
            get { return this.sender; }
            set
            {
                this.sender = value;
                this.NotifyPropertyChanged("Sender");
            }
        }
        [DataMember]
        public IList<User> Recievers
        {
            get { return this.recievers; }
            set
            {
                this.recievers = value;
                this.NotifyPropertyChanged("Recievers");
            }
        }
        [DataMember]
        public byte[] Payload
        {
            get { return this.Payload; }
            set
            {
                this.payload = value;
                this.NotifyPropertyChanged("Payload");
            }
        }
    }
}
