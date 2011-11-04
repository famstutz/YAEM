using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace YAEM.Domain
{
    [DataContract]
    public class User
    {
        [DataMember]
        public String Name { get; set; }
    }
}
