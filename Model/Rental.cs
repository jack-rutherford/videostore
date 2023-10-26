using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rental
    {
        public Video Video { get;  set; }
        public Customer Customer { get;  set; }
        public DateTime RentalDate { get;  set; }
        public DateTime DueDate { get;  set; }
        public int Id { get;  set; }
    }
}
