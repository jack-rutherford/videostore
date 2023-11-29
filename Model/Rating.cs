using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rating
    {
        public virtual int Score { get;  set; }
        public virtual int Id { get;  set; }
        public virtual string Comment { get; set; }
        public Rating() { }

        public override int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(Object obj)
        {
            if (obj is Rating)
            {
                Rating other = (Rating)obj;
                return other.Id == this.Id;
            }
            return false;
        }
    }
}
