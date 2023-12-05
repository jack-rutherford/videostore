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
            ZipCode zip = new ZipCode()
            {
                Code = "49423",
                City = "Holland",
                State = "MI"
            };
            new PersistenceSpecification<Customer>(_session)
                .CheckProperty(x => x.EmailAddress, "john.doe@hope.edu")
                .CheckProperty(x => x.Phone, "616-555-1212")
                .CheckProperty(x => x.StreetAddress, "123 Main St")
                .CheckProperty(x => x.Password, "passworD3")
                .CheckProperty(x => x.Name.First, "John")
                .CheckProperty(x => x.Name.Last, "Doe")
                .CheckProperty(x => x.Name.Middle, "Q")
                .CheckProperty(x => x.Name.Suffix, "Jr")
                .CheckProperty(x => x.Name.Title, "Mr")
                .CheckReference(x => x.ZipCode, zip)
                .CheckList(x => x.PreferredStores, new List<Store>()
                {
                        new Store(){ StreetAddress = "123 Main St", ZipCode = zip },
                        new Store(){ StreetAddress = "456 Main St", ZipCode = zip }
                    },
                    (customer, store) => customer.AddPreferredStore(store)
                )
                .VerifyTheMappings();
        }

    }
}
