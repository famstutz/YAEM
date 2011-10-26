using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace YAEM.Domain
{
    [DataContract]
    public class Session
    {
        [DataMember]
        public Guid SessionKey { get; set; }
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public DateTime ExpiryDate { get; set; }
    }
}
