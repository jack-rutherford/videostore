using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rental
    {
        public virtual ZipCode Video { get;  set; }
        public virtual Customer Customer { get;  set; }
        public virtual DateTime RentalDate { get;  set; }
        public virtual DateTime DueDate { get;  set; }
        public virtual DateTime? ReturnDate { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual int Id { get;  set; }
        public Rental() { }
        public int GetHashCode()
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
    }
}
