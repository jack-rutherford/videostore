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
            ISet<ZipCode> zips = new HashSet<ZipCode>();
            ZipCode code1 = new ZipCode()
            {
                Code = "49424",
            };

            ZipCode code2 = new ZipCode()
            {
                Code = "49424",
            };

            Assert.IsFalse(zips.Contains(code1), "Code1 found in ZipCode Set, should not be found");
            Assert.IsFalse(zips.Contains(code2), "Code2 found in ZipCode Set, should not be found");
            zips.Add(code1);
            zips.Add(code2);
            Assert.IsTrue(zips.Contains(code1), "Code1 Not found in ZipCode Set");
            Assert.IsTrue(zips.Contains(code2), "Code2 Not found in ZipCode Set");
        }

        [TestMethod]
        public void TestRemoveZipCode()
        {
            ISet<ZipCode> zips = new HashSet<ZipCode>();
            ZipCode code1 = new ZipCode()
            {
                Code = "49424",
            };

            ZipCode code2 = new ZipCode()
            {
                Code = "49424",
            };

            zips.Add(code1);
            zips.Add(code2);
            Assert.IsTrue(zips.Contains(code2));
            zips.Remove(code2);
            Assert.IsFalse(zips.Contains(code2));
        }
    }
}
