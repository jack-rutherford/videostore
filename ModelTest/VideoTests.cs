using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using VideoStore.Utilities;

namespace ModelTest
{
    [TestClass]
    public class VideoTests
    {
        Video video1 = new Video()
        {
            Id = 1,
            PurchaseDate = DateFactory.TestDate,
            NewArrival = false,
        };

        Video video2 = new Video()
        {
            Id = 1,
            PurchaseDate = DateFactory.TestDate,
            NewArrival = true,
        };

        [TestMethod]
        public void TestPurchaseDate()
        {
            Assert.IsNotNull(video1);
            Assert.AreEqual(video1.PurchaseDate, DateFactory.TestDate);
        }

        [TestMethod]
        public void TestEqual()
        {
            Assert.AreEqual(video1.Id, video2.Id);
        }
    }
}
