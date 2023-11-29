using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommunicationMethod
    {
        public virtual string Name { get;  set; }
        public virtual int Id { get;  set; }
        public virtual ISet<Customer> Customers { get; protected internal set; }
        public virtual int Frequency { get; set; }
        public virtual TimeUnit Units { get; set; }
        public enum TimeUnit {Day, Week, Month, Year};
        public CommunicationMethod() 
        { 
            Customers = new HashSet<Customer>();
        }
        public override int GetHashCode()
        {
            return Id;
        }
        public override bool Equals(Object obj)
        {
            if (obj is CommunicationMethod)
            {
                CommunicationMethod other = (CommunicationMethod)obj;
                return other.Name.Equals(this.Name);
            }
            return false;
        }
    }
}
