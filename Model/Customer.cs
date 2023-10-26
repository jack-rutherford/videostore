using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        public Name Name { get;  set; }
        public IList<Store> PreferredStores { get; protected internal set; }
        public string Password { get;  set; }
        public string FullName { get;  set; }
        public string EmailAddress { get;  set; }
        public IList<Rental> LateRentals { get; protected internal set; }
        public IList<Rental> Rentals { get; protected internal set; }
        public Reservation Reservation { get;  set; }
        public int Id { get;  set; }
        public string StreetAddress { get; set; }
        public string Phone { get; set; }
        public ZipCode ZipCode { get; set; }
        public IList<CommunicationMethod> CommunicationTypes { get; protected internal set; }

    }
}
