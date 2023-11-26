using System;

using NHibernate;
using NHibernate.Context;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Data.SqlClient;
using FluentNHibernate.Mapping;

namespace Mappings
{
    public class SessionFactory
    {
        public static ClassMap<object> initialMap;

        public static ISessionFactory CreateSessionFactory<T>(String defaultSchema)
        {
            var builder = new SqlConnectionStringBuilder();
            if (System.Environment.GetEnvironmentVariables().Contains("SERVER_392"))
            {
                builder["server"] = System.Environment.GetEnvironmentVariable("SERVER_392");
            }
            else
            {
                builder["server"] = "(LocalDB)\\MSSQLLocalDB";
            }

            builder["Integrated Security"] = false;
            builder["Initial Catalog"] = System.Environment.GetEnvironmentVariable("USERNAME_392");
            builder["User Id"] = System.Environment.GetEnvironmentVariable("USERNAME_392");
            builder["Password"] = System.Environment.GetEnvironmentVariable("PASSWORD_392");

            return Fluently.Configure()
              .Database(
                MsSqlConfiguration.MsSql2012
                  .ConnectionString(builder.ConnectionString)
                  .DefaultSchema(defaultSchema)
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>())
                .ExposeConfiguration(x => x.CurrentSessionContext<ThreadLocalSessionContext>())
                .BuildSessionFactory();
        }
    }
}
