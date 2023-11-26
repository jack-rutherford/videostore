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
    public class TestCustomer : BaseTest
    {
        [Test]
        public void TestCustomerMapping()
        {
            new PersistenceSpecification<Customer>(_session)
                .CheckProperty(x => x.Id, 1)
                .CheckProperty(x => x.EmailAddress, "john.doe@hope.edu")
                .VerifyTheMappings();
        }

    }
}
