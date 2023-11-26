using FluentNHibernate.Mapping;
using Model;
using NHibernate.Cfg.XmlHbmBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings
{
    public class AreaMap : ClassMap<Area>
    {
        public AreaMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            //HasMany(x => x.ZipCodes).Cascade.All();
        }
    }
}
