using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        public Name Name { get; protected internal set; }
        public IList<Store> PreferredStores { get; protected internal set; }
        public string Password { get; protected internal set; }
        public string FullName { get; protected internal set; }
        public string EmailAddress { get; protected internal set; }
        public IList<Rental> LateRentals { get; protected internal set; }
        public IList<Rental> Rentals { get; protected internal set; }
        public Reservation Reservation { get; protected internal set; }
        public int Id { get; protected internal set; }
    }
}
