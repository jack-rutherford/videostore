using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommunicationMethod
    {
        public string Name { get;  set; }
        public int Id { get;  set; }
        public ISet<Customer> Customers { get; protected internal set; }
        public int Frequency { get; set; }
        public TimeUnit Units { get; set; }
        public enum TimeUnit {Day, Week, Month, Year};
    }
}
