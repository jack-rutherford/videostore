using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Diagnostics;
using System.Threading;

namespace ModelTest
{
    [TestClass]
    public class ZipCodeTests
    {
        ZipCode zip1 = new ZipCode()
        {
            Code = "49424",
            City = "Holland",
        };

        ZipCode zip2 = new ZipCode()
        {
            Code = "49424",
            City = "Holland",
        };

        [TestMethod]
        public void TestHashCode()
        {
            Assert.AreEqual(zip1.GetHashCode(), "49424".GetHashCode());
        }

        public Boolean TestEqualsMethod(ZipCode zip1, ZipCode zip2)
        {
            if(zip1.Code == zip2.Code) return true;
            return false;
        }

        [TestMethod]
        public void TestEqual()
        {
            Assert.AreEqual(TestEqualsMethod(zip1, zip2), zip1.Code.Equals(zip2.Code));
        }
    }
}
