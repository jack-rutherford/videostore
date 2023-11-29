using Mappings;
using NHibernate;
using NUnit.Framework;
using System;

namespace MappingTests
{
    [TestFixture]
    public class BaseTest
    {
        protected ISessionFactory _factory;
        protected ISession _session;

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
            _session.CreateSQLQuery("delete from VideoStore.Store")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from VideoStore.ZipCode")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from VideoStore.Video")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from VideoStore.Area")
                .ExecuteUpdate();

        }
    }
}