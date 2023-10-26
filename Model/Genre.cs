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
        public string GetHashCode()
        {
            return Name;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Genre a2 = obj as Genre;
            if (this.Name.Equals(a2.Name)) return true;
            return false;
        }
    }
}
