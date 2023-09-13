using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;

namespace ModelTest
{
    [TestClass]
    public class AreaTests
    {
        
        [TestMethod]
        public void TestAddZipCode()
        {
            Area area = new Area()
            {
                ZipCodes = new HashSet<ZipCode>()
            };
            ZipCode code1 = new ZipCode()
            {
                Code = "49424",
            };

            ZipCode code2 = new ZipCode()
            {
                Code = "49424",
            };

            Assert.IsFalse(area.ZipCodes.Contains(code1), "Code1 found in ZipCode Set, should not be found");
            Assert.IsFalse(area.ZipCodes.Contains(code2), "Code2 found in ZipCode Set, should not be found");
            area.ZipCodes.Add(code1);
            area.ZipCodes.Add(code2);
            Assert.IsTrue(area.ZipCodes.Contains(code1), "Code1 Not found in ZipCode Set");
            Assert.IsTrue(area.ZipCodes.Contains(code2), "Code2 Not found in ZipCode Set");
        }

        [TestMethod]
        public void TestRemoveZipCode()
        {
            Area area = new Area()
            {
                ZipCodes = new HashSet<ZipCode>()
            };
            ZipCode code1 = new ZipCode()
            {
                Code = "49424",
            };

            ZipCode code2 = new ZipCode()
            {
                Code = "49424",
            };

            area.ZipCodes.Add(code1);
            area.ZipCodes.Add(code2);
            Assert.IsTrue(area.ZipCodes.Contains(code2));
            area.ZipCodes.Remove(code2);
            Assert.IsFalse(area.ZipCodes.Contains(code2));
        }

        public Boolean TestEqualMethod(Area area1, Area area2)
        {
            return area1.Name.Equals(area2.Name);
        }

        [TestMethod]
        public void TestEqual()
        {
            Area area1 = new Area()
            {
                Name = "Foo",
            };
            Area area2 = new Area()
            {
                Name = "Foo",
            };
            Assert.AreEqual(TestEqualMethod(area1, area2), area1.Name.Equals(area2.Name));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Area area = new Area();
            Assert.AreEqual(area.Id, area.GetHashCode());
        }
    }
}
