using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
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
        public Customer() 
        { 
            PreferredStores = new List<Store>();
            LateRentals = new List<Rental>();
            Rentals = new List<Rental>();
            CommunicationTypes = new List<CommunicationMethod>();
        }
        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Customer a2 = obj as Customer;
            if (this.EmailAddress.Equals(a2.EmailAddress)) return true;
            return false;
        }

        public Reservation AddReservation(Movie movie)
        {
            return null;
        }

        public Rental Rent(Video video)
        {
            return null;
        }

        public void Allow(CommunicationMethod method)
        {
            
        }

        public void Deny(CommunicationMethod method)
        {
            
        }

        public void AddPreferredStore(Store store3, int v = -1)
        {
            
        }

        public void RemovePreferredStore(Store store1)
        {
            
        }
    }
}
