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
        private string _code;

        public virtual string Code 
        { 
            get { return _code; }
            set
            {
                //ZipCode must be 5 digits long or 9 digits long separated by a dash (-)
                if (value.Length == 5 || value.Length == 10)
                {
                    if(value.Length == 10)
                    {
                        if (value[5] != '-') throw new ArgumentException("ZipCode must be 5 digits long or 9 digits long separated by a dash (-)");
                    }
                    _code = value;
                }
                else
                {
                    throw new ArgumentException("ZipCode must be 5 digits long or 9 digits long separated by a dash (-)");
                }

            } 
        }
        public virtual string City { get;  set; }
        public virtual string State { get;  set;}
        public ZipCode() { }
        public override int GetHashCode()
        {
            return Code.GetHashCode();
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
