using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Utilities;

namespace Model
{
    public class Customer
    {
        public virtual Name Name { get;  set; }
        //There is order for PreferredStores
        public virtual IList<Store> PreferredStores { get; protected internal set; }
        public virtual string Password
        {
            get { return _password; }
            set
            {
                if (value.Length < 6 || !value.Any(char.IsUpper) || !value.Any(char.IsLower) || !value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Password must be at least 6 characters long, contain a mix of upper and lower case, and have at least one number.");
                }

                _password = value;
            }
        }

        private string _password;
        public virtual string FullName 
        {
            get { return Name.First + " " + Name.Last; }
        }

        private string _fullname;

        public virtual string EmailAddress { get;  set; }
        public virtual IList<Rental> LateRentals 
        {
            get 
            {
                IEnumerable<Rental> lateRentals = Rentals.Where(Rentals => Rentals.DueDate < DateFactory.CurrentDate).OrderBy(rental => rental.DueDate);
                return lateRentals.ToList();
            }
        }
        private IList<Rental> _lateRentals;
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
            Rentals = new List<Rental>();
            CommunicationTypes = new HashSet<CommunicationMethod>();
            Name = new Name();
            Reservation = new Reservation();
            ZipCode = new ZipCode();
        }
        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Customer)
            {
                Customer other = (Customer)obj;
                return other.EmailAddress.Equals(this.EmailAddress);
            }
            return false;
        }

        public virtual Reservation AddReservation(Movie movie)
        {
            return null;
        }

        public virtual Rental Rent(Video video)
        {
            // Creates a new Rental for this customer / video, adding it to the list
            // of rentals for this customer.
            Rental rental = new Rental(this, video);
            this.Rentals.Add(rental);
            return rental;
        }

        public virtual void Allow(CommunicationMethod method)
        {
            // Specifies this customer wishes to receive communications via the specified method;
            // Also modifies the appropriate CommunicationMethod customer list
            this.CommunicationTypes.Add(method);
            method.Customers.Add(this);
        }

        public virtual void Deny(CommunicationMethod method)
        {
            // Specifies this customer does not wish to receive communications via the specified method;
            // Also modifies the appropriate CommunicationMethod customer list
            this.CommunicationTypes.Remove(method);
            method.Customers.Remove(this);
        }

        /*Adds a Store to the list of preferred
        stores for this customer, at the
        position indicated by the second
        parameter.The second parameter
        should be optional, with a default
        value of -1, in which case the store
        will be made the last item in the list.
        If the Store already exists in the list
        of preferred stores, it should be
        moved to the position indicated by
        the second parameter.*/
        public virtual void AddPreferredStore(Store store, int v = -1)
        {
            if (PreferredStores.Contains(store))
            {
                PreferredStores.Remove(store);

                if (v == -1)
                {
                    this.PreferredStores.Add(store);
                }
                else
                {
                    this.PreferredStores.Insert(v, store);
                }
            }
            else
            {
                if (v == -1)
                {
                    this.PreferredStores.Add(store);
                }
                else
                {
                    this.PreferredStores.Insert(v, store);
                }
            }
        }

        /*Removes a Store from this
        customer's list of preferred stores,
        shifting subsequent stores up. If the
        Store doesn't exist in the list of
        preferred stores for this customer,
        throw an ArgumentException*/
        public virtual void RemovePreferredStore(Store store)
        {
            if (!this.PreferredStores.Contains(store))
            {
                throw new ArgumentException("This store is not a part of Customer's preferred stores list");
            }
            this.PreferredStores.Remove(store);
        }

        public override string ToString()
        {
            return String.Format("ID {0}, EmailAddress {1}, Phone {2}, StreetAddress {3}", Id, EmailAddress, Phone, StreetAddress);
        }

    }
}
