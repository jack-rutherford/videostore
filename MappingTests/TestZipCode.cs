using FluentNHibernate.Testing;
using Mappings;
using Model;
using NHibernate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingTests
{
    [TestFixture]
    public class TestZipCode : BaseTest
    {
        [Test]
        public void TestZipCodeMapping()
        {
            new PersistenceSpecification<ZipCode>(_session)
                .CheckProperty(x => x.Code, "49423")
                .CheckProperty(x => x.City, "Holland")
                .CheckProperty(x => x.State, "MI")
                .VerifyTheMappings();
        }
    }
}
