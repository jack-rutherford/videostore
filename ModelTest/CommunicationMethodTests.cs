using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;

namespace ModelTest
{
    [TestClass]
    public class CommunicationMethodTests
    {
        public Boolean TestEqualMethod(CommunicationMethod c1, CommunicationMethod c2)
        {
            return c1.Name.Equals(c2.Name);
        }
        [TestMethod]
        public void TestEqual()
        {
            CommunicationMethod c1 = new CommunicationMethod() { Name = "A" };
            CommunicationMethod c2 = new CommunicationMethod() { Name = "A" };
            Assert.AreEqual(TestEqualMethod(c1,c2), c1.Equals(c2));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            CommunicationMethod c = new CommunicationMethod() { Name = "A" };
            Assert.AreEqual(c.GetHashCode(), c.Id);
        }
    }
}
