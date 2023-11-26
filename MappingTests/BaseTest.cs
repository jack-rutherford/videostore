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
            // Replace "stu.dent" with your user name in the 2 calls below
            Environment.SetEnvironmentVariable("VideoStore.DB", "jack.rutherford");
            Environment.SetEnvironmentVariable("VideooreSt.UID", "jack.rutherford");
            // Replace "########" with your 9-digit student number
            Environment.SetEnvironmentVariable("VideoStore.PW", "000427252");
            Environment.SetEnvironmentVariable("VideoStore.Server", "localhost");

            //_factory = SessionFactory.CreateSessionFactory<CustomerMap>();
            _session = SessionFactory.CreateSessionFactory<CustomerMap>("VideoStore").
                GetCurrentSession();
            //_session.CreateSQLQuery("delete from VideoStore.Employee")
            //    .ExecuteUpdate();
            //_session.CreateSQLQuery("delete from VideoStore.Store")
            //    .ExecuteUpdate();

        }
    }
}