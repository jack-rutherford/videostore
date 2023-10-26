using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rental
    {
        public Video Video { get; protected internal set; }
        public Customer Customer { get; protected internal set; }
        public DateTime RentalDate { get; protected internal set; }
        public DateTime DueDate { get; protected internal set; }
        public int Id { get; protected internal set; }
    }
}
