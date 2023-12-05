using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Model;

namespace Mappings
{
    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Id(x => x.Id);
            Map(x => x.PhoneNumber);
            Map(x => x.StreetAddress);
            References(x => x.ZipCode, "ZipCode_Id").Cascade.All();
            HasMany(x => x.Videos)
                .Cascade.All()
                .Inverse();
        }

    }
}