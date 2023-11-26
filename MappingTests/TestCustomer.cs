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
    public class TestCustomer
    {
        private ISessionFactory _factory;
        private ISession _session;
        [SetUp]
        public void CreateSession()
        {
            // Replace "stu.dent" with your user name in the 2 calls
            // below
            Environment.SetEnvironmentVariable("VideoStore.DB", 
                "jack.rutherford");
            Environment.SetEnvironmentVariable("VideoStore.UID",
                "jack.rutherford");
            // Replace "########" with your 9-digit student number
            Environment.SetEnvironmentVariable("VideoStore.PW",
                "000427252");
            Environment.SetEnvironmentVariable("VideoStore.Server",
                "localhost");
            _factory = SessionFactory.CreateSessionFactory<CustomerMap>("VideoStore");
            _session = _factory.GetCurrentSession();
            _session.CreateSQLQuery("delete from VideoStore.Customer")
                .ExecuteUpdate();

        }
        [Test]
        public void TestCustomerMapping()
        {
            new PersistenceSpecification<Customer>(_session)
                .CheckProperty(x => x.EmailAddress, "john.doe@hope.edu")
                .CheckProperty(x => x.Phone, "616-555-1212")
                .CheckProperty(x => x.StreetAddress, "123 Main St")
                .CheckProperty(x => x.Password, "password")
                .CheckProperty(x => x.Name.First, "John")
                .CheckProperty(x => x.Name.Last, "Doe")
                .CheckProperty(x => x.Name.Middle, "Q")
                .CheckProperty(x => x.Name.Suffix, "Jr")
                .CheckProperty(x => x.Name.Title, "Mr")
                .VerifyTheMappings();
        }

    }
}
