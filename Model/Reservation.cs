using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reservation
    {
        public DateTime ReservationDate { get; internal set; }
        public Movie Movie { get;  set; }
        public Customer Customer { get;  set; }
        public int Id { get;  set; }
    }
}
