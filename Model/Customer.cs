using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public virtual class Customer
    {
        public virtual Name Name { get;  set; }
        public virtual IList<Store> PreferredStores { get; protected internal set; }
        public virtual string Password { get;  set; }
        public virtual string FullName { get; }
        public virtual string EmailAddress { get;  set; }
        public virtual IList<Rental> LateRentals { get; }
        public virtual IList<Rental> Rentals { get; protected internal set; }
        public virtual Reservation Reservation { get;  set; }
        public virtual int Id { get;  set; }
        public virtual string StreetAddress { get; set; }
        public virtual string Phone { get; set; }
        public virtual ZipCode ZipCode { get; set; }
        public virtual IList<CommunicationMethod> CommunicationTypes { get; protected internal set; }

    }
}
