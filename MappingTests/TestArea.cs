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
    public class TestArea
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
            _factory = SessionFactory.CreateSessionFactory<AreaMap>("VideoStore");
            _session = _factory.GetCurrentSession();
            _session.CreateSQLQuery("delete from VideoStore.Area")
                .ExecuteUpdate();

        }
        [Test]
        public void TestAreaMapping()
        {
            new PersistenceSpecification<Area>(_session)
                .CheckProperty(x => x.Name, "Holland")
                .VerifyTheMappings();
        }

    }
}
