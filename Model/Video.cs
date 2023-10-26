using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Video
    {
        public int Id { get; protected internal set; }
        public bool NewArrival { get; protected internal set; }
        public Movie Movie { get; protected internal set; }
        public DateTime PurchaseDate { get; protected internal set; }
    }
}
