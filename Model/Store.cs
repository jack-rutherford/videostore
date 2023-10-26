using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Store
    {
        public string StreetAddress { get;  set; }
        public ZipCode ZipCode { get;  set; }
        public IList<Employee> Managers { get; protected internal set; }
        public IList<Video> Videos { get; protected internal set; }
        public int Id { get;  set; }
        public string PhoneNumber { get; set; }
    }
}
