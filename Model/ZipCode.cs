using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ZipCode
    {
        public virtual string Code { get;  set; }
        public virtual string City { get;  set; }
        public virtual string State { get;  set;}
    }
}
