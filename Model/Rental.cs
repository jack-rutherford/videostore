using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
