using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace YAEM.Domain
{
    [DataContract]
    public class User : ObjectBase
    {
        private string name;

        [DataMember]
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.NotifyPropertyChanged("Name");
            }
        }

        public User() : base()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
