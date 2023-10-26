using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public virtual class Area
    {
        public virtual HashSet<ZipCode> ZipCodes { get; protected internal set; }
        public virtual string Name { get;  set; }
        public virtual int Id { get; set; }
    }
}
