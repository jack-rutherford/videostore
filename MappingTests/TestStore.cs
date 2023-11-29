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
    public class TestStore : BaseTest
    {
        [Test]
        public void TestStoreMapping()
        {
            ZipCode zip = new ZipCode()
            {
                Code = "49423",
                City = "Holland",
                State = "MI"
            };
            new PersistenceSpecification<Store>(_session)
                .CheckProperty(x => x.PhoneNumber, "616-555-1212")
                .CheckProperty(x => x.StreetAddress, "123 Main St")
                .CheckReference(x => x.ZipCode, zip)
                .VerifyTheMappings();
        }
    }
}
