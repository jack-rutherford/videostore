using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Model;

namespace Mappings
{
    public class VideoMap : ClassMap<Video>
    {
        public VideoMap()
        {
            Id(x => x.Id);
            Map(x => x.NewArrival);
        }

    }
}