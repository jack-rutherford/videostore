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
    public class TestArea : BaseTest
    {
        [Test]
        public void TestAreaMapping()
        {
            new PersistenceSpecification<Area>(_session)
                .CheckProperty(x => x.Name, "Holland")
                .VerifyTheMappings();
        }

    }
}
