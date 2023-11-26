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
            Component(x => x.Name, m =>
            {
                m.Map(x => x.First);
                m.Map(x => x.Last);
                m.Map(x => x.Middle);
                m.Map(x => x.Suffix);
                m.Map(x => x.Title);
            });
            Map(x => x.EmailAddress);
            Map(x => x.Phone);
            Map(x => x.StreetAddress);
            Map(x => x.Password);
        }
    
    }
}
