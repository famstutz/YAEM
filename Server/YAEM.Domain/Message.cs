using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace YAEM.Domain
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public User Sender { get; set; }
        [DataMember]
        public IList<User> Recievers { get; set; }
        [DataMember]
        public byte[] Payload { get; set; }
    }
}
