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
            Console.WriteLine("%d", zip1.GetHashCode());
            Console.WriteLine("%d", 49424.GetHashCode());
            Assert.AreEqual(zip1.GetHashCode(), "49424".GetHashCode());
        }

        [TestMethod]
        public void TestEquals()
        {
            Assert.AreEqual(zip1.Code, zip2.Code);
        }
    }
}
