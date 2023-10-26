using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ZipCode
    {
        public virtual string Code { get;  set; }
        public virtual string City { get;  set; }
        public virtual string State { get;  set;}
        public ZipCode() { }
        public int GetHashCode()
        {
            return Int32.Parse(Code);
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;

            ZipCode a2 = obj as ZipCode;
            if (this.Code.Equals(a2.Code)) return true;
            return false;
        }
    }
}
