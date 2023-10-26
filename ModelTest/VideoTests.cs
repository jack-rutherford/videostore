using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using VideoStore.Utilities;

namespace ModelTest
{
    [TestClass]
    public class VideoTests
    {
        ZipCode video1 = new ZipCode()
        {
            Id = 1,
            PurchaseDate = DateFactory.CurrentDate,
            NewArrival = false,
        };

        ZipCode video2 = new ZipCode()
        {
            Id = 1,
            PurchaseDate = DateFactory.CurrentDate,
            NewArrival = true,
        };

        ZipCode video3 = new ZipCode()
        {
            Id = 2,
            PurchaseDate = DateFactory.CurrentDate,
            NewArrival = true,
        };

        [TestMethod]
        public void TestPurchaseDate()
        {
            Assert.IsNotNull(video1);
            Assert.AreEqual(video1.PurchaseDate, DateFactory.CurrentDate);
        }

        public Boolean TestEqualsMethod(ZipCode vid1, ZipCode vid2)
        {
            return vid1.Id.Equals(vid2.Id);
        }

        [TestMethod]
        public void TestEqual()
        {
            Assert.AreEqual(TestEqualsMethod(video1, video2), video1.Equals(video2));
        }
    }
}
