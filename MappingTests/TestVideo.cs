using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NHibernate;
using FluentNHibernate.Testing;
using Model;
using Mappings;

namespace MappingTests
{
    [TestFixture]
    public class TestVideo : BaseTest
    {
        [Test]
        public void TestVideoMapping()
        {
            ZipCode zip = new ZipCode()
            {
                Code = "49423",
                City = "Holland",
                State = "MI"
            };
            new PersistenceSpecification<Video>(_session)
                .CheckProperty(x => x.NewArrival, true)
                .CheckReference(x => x.Store, new Store()
                {
                    StreetAddress = "2822 Blue Smoke",
                    ZipCode = zip
                })
                .VerifyTheMappings();
        }

    }
}
