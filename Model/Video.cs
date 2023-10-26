using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Video
    {
        public virtual int Id { get; set; }
        public virtual bool NewArrival { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual DateTime PurchaseDate { get; set; }
        public virtual Store Store { get; set; }
    }
}
