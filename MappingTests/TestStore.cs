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
    public class TestStore
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
            _factory = SessionFactory.CreateSessionFactory<StoreMap>("VideoStore");
            _session = _factory.GetCurrentSession();
            _session.CreateSQLQuery("delete from VideoStore.Store")
                .ExecuteUpdate();

        }
        [Test]
        public void TestStoreMapping()
        {
            new PersistenceSpecification<Store>(_session)
                .CheckProperty(x => x.PhoneNumber, "616-555-1212")
                .CheckProperty(x => x.StreetAddress, "123 Main St")
                .VerifyTheMappings();
        }
    }
}
