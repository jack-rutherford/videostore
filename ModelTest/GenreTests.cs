using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;

namespace ModelTest
{
    [TestClass]
    public class GenreTests
    {

        public Boolean TestEqualMethod(Genre g1, Genre g2)
        {
            return g1.Name.Equals(g2.Name);
        }

        [TestMethod]
        public void TestEqual()
        {
            Genre g1 = new Genre()
            {
                Name = "A",
            };
            Genre g2 = new Genre()
            {
                Name = "A",
            };
            Assert.AreEqual(TestEqualMethod(g1,g2), g1.Equals(g2));
        }
    }
}
