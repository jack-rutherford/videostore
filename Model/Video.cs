using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Video
    {
        public int Id { get; set; }
        public bool NewArrival { get; set; }
        public Movie Movie { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Store Store { get; set; }
    }
}
