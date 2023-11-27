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

                IEnumerable<Rental> lateRentals = Rentals.Where(Rentals => Rentals.DueDate < DateFactory.CurrentDate).OrderByDescending(rental => rental.DueDate);
                return lateRentals.ToList();
                //_lateRentals = new List<Rental>();
                //foreach (Rental rental in Rentals)
                //{
                //    if (rental.DueDate < DateFactory.CurrentDate)
                //    {
                //        _lateRentals.Add(rental);
                //    }
                //}
                //_lateRentals.OrderByDescending(x => x.DueDate);
                //return _lateRentals;
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
            //LateRentals = new List<Rental>();
            Rentals = new List<Rental>();
            CommunicationTypes = new HashSet<CommunicationMethod>();
            Name = new Name();
            Phone = "";
            StreetAddress = "";
            EmailAddress = "";
            Password = "Default2";
            //FullName = "";
            Id = 0;
            Reservation = new Reservation();
            ZipCode = new ZipCode();
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
            // Creates a new Rental for this customer / video, adding it to the list
            // of rentals for this customer.
            //Rental rental = new Rental(this, video);
            //this.Rentals.Add(rental);
            //return rental;
            return null;
        }

        public virtual void Allow(CommunicationMethod method)
        {
            // Specifies this customer wishes to receive communications via the specified method;
            // Also modifies the appropriate CommunicationMethod customer list
            //this.CommunicationTypes.Add(method);
            //method.Customers.Add(this);
        }

        public virtual void Deny(CommunicationMethod method)
        {
            // Specifies this customer does not wish to receive communications via the specified method;
            // Also modifies the appropriate CommunicationMethod customer list
            //this.CommunicationTypes.Remove(method);
            //method.Customers.Remove(this);
        }

        public virtual void AddPreferredStore(Store store3, int v = -1)
        {
            
        }

        public virtual void RemovePreferredStore(Store store1)
        {
            
        }

        public override string ToString()
        {
            return String.Format("ID {0}, EmailAddress {1}, Phone {2}, StreetAddress {3}", Id, EmailAddress, Phone, StreetAddress);
        }

    }
}
