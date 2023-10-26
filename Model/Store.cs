using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Store
    {
        public virtual string StreetAddress { get;  set; }
        public virtual ZipCode ZipCode { get;  set; }
        public virtual IList<Employee> Managers { get; protected internal set; }
        public virtual IList<Video> Videos { get; protected internal set; }
        public virtual int Id { get;  set; }
        public virtual string PhoneNumber { get; set; }
    }
}
