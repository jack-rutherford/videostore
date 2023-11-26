using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Model;

namespace Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);
            //Map(x => x.Name.First);
            //Map(x => x.Name.Last);
            //Map(x => x.Name.Middle);
            //Map(x => x.Name.Suffix);
            //Map(x => x.Name.Title);
            Map(x => x.EmailAddress);
            Map(x => x.Phone);
            Map(x => x.StreetAddress);
            Map(x => x.Password);
        }
    
    }
}
