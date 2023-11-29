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
            if (obj is Reservation)
            {
                Reservation other = (Reservation)obj;
                return this.Movie.Equals(other.Movie) && this.Customer.Equals(other.Customer);
            }
            return false;
        }
    }
}
