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
    }
}
