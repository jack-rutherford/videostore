using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Name
    {
        public virtual String First { get;  set; }
        public virtual String Last { get;  set; }
        public virtual String Title { get; set; }
        public virtual String Middle { get; set; }
        public virtual String Suffix { get; set; }
        public Name() { }

    }
}
