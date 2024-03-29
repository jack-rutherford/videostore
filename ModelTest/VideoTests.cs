﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            PurchaseDate = DateFactory.CurrentDate,
            NewArrival = false,
        };

        Video video2 = new Video()
        {
            Id = 1,
            PurchaseDate = DateFactory.CurrentDate,
            NewArrival = true,
        };

        Video video3 = new Video()
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

        public Boolean TestEqualsMethod(Video vid1, Video vid2)
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
