using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Area
    {
        public virtual HashSet<ZipCode> ZipCodes { get; protected internal set; }
        public virtual string Name { get;  set; }
        public virtual int Id { get; set; }
        public Area() 
        { 
            ZipCodes = new HashSet<ZipCode>();
        }
        public override int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(Object obj)
        {
            if (obj is Area)
            {
                Area other = (Area)obj;
                return other.Id == this.Id;
            }
            return false;
        }
        public virtual void AddZipCode(ZipCode zip)
        {
            this.ZipCodes.Add(zip);
        }
        public virtual void RemoveZipCode(ZipCode zip)
        {
            //Removes the desired ZipCode from this Area.
            //Throws an ArgumentException if the ZipCode does not exist in the ZipCodes set.
            if (!this.ZipCodes.Contains(zip)) throw new ArgumentException("ZipCode does not exist in this Area");
            this.ZipCodes.Remove(zip);
        }
    }
}
