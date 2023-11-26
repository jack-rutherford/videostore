using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Utilities;

namespace Model
{
    public class Rental
    {
        public virtual Video Video { get;  set; }
        public virtual Customer Customer { get;  set; }
        public virtual DateTime RentalDate { get;  set; }
        public virtual DateTime DueDate { get;  set; }
        public virtual DateTime? ReturnDate { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual int Id { get;  set; }
        public Rental(Customer c, Video v)
        {
            Customer = c;
            Video = v;
            RentalDate = DateFactory.CurrentDate;
            if(Video.NewArrival == true)
            {
                DueDate = RentalDate.AddDays(3);
            }
            else
            {
                DueDate = RentalDate.AddDays(7);
            }
            ReturnDate = null;
            Rating = null;
        }
        public override int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(Object obj)
        {
            if(obj == null || this.GetType() != obj.GetType()) return false;

            Rental a2 = obj as Rental;
            if (this.Video.Equals(a2.Video) && this.Customer.Equals(a2.Customer) && this.RentalDate.Equals(a2.RentalDate)) return true;
            return false;
        }

        public virtual ReturnReceipt Return()
        {
            return null;
        }

        public class ReturnReceipt
        {
            public ReturnReceipt() { }
            public virtual Reservation FulfilledReservation { get; set; }
            public virtual Rental NextRental { get; set; }
        }
    }
}
