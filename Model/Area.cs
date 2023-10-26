using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Area
    {
        public HashSet<ZipCode> ZipCodes { get; protected internal set; }
        public string Name { get;  set; }
        public int Id { get; set; }
    }
}
