using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reservation
    {
        public virtual DateTime ReservationDate { get; internal set; }
        public virtual Movie Movie { get;  set; }
        public virtual Customer Customer { get;  set; }
        public virtual int Id { get;  set; }
        public Reservation() { }
        public override int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Reservation a2 = obj as Reservation;
            if (this.Movie.Equals(a2.Movie) && this.Customer.Equals(a2.Customer)) return true;
            return false;
        }
    }
}
