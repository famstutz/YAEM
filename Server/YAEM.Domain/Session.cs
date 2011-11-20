using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace YAEM.Domain
{
    [DataContract]
    public class Session : ObjectBase
    {
        private User user;
        private DateTime expiryDate;

        [DataMember]
        public User User
        {
            get { return this.user; }
            set
            {
                this.user = value;
                this.NotifyPropertyChanged("User");
            }
        }

        [DataMember]
        public DateTime ExpiryDate
        {
            get { return this.expiryDate; }
            set
            {
                this.expiryDate = value;
                this.NotifyPropertyChanged("ExpiryDate");
            }
        }

         public Session() : base()
        {

        }
    }
}
