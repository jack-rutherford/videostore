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
        public virtual ISet<CommunicationMethod> CommunicationTypes { get; protected internal set; }
        public Customer() 
        { 
            PreferredStores = new List<Store>();
            LateRentals = new List<Rental>();
            Rentals = new List<Rental>();
            CommunicationTypes = new HashSet<CommunicationMethod>();
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

        public virtual Reservation AddReservation(Movie movie)
        {
            return null;
        }

        public virtual Rental Rent(Video video)
        {
            return null;
        }

        public virtual void Allow(CommunicationMethod method)
        {
            
        }

        public virtual void Deny(CommunicationMethod method)
        {
            
        }

        public virtual void AddPreferredStore(Store store3, int v = -1)
        {
            
        }

        public virtual void RemovePreferredStore(Store store1)
        {
            
        }
    }
}
