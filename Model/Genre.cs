using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Genre
    {
        public virtual string Name { get;  set; }
        public Genre() { }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override bool Equals(Object obj)
        {
            if (obj is Genre)
            {
                Genre other = (Genre)obj;
                return other.Name.Equals(this.Name);
            }
            return false;
        }
    }
}
