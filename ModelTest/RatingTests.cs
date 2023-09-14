using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;

namespace ModelTest
{
    [TestClass]
    public class RatingTests
    {
        [TestMethod]
        public void TestScore()
        {
            Rating rating1 = new Rating() { Score = 1 };
            Assert.IsTrue(rating1.Score >= 1 && rating1.Score <= 5);
            try
            {
                Rating rating2 = new Rating() { Score = 12 };
                Assert.Fail("Score should not be able to be not between 1 and 5, does not throw exception");
            } catch (Exception e) { }
        }
        public Boolean TestEqualMethod(Rating r1, Rating r2)
        {
            return r1.Id.Equals(r2.Id);
        }

        [TestMethod]
        public void TestEqual()
        {
            Rating r1 = new Rating();
            Rating r2 = new Rating();
            Assert.AreEqual(TestEqualMethod(r1, r2), r2.Equals(r1));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Rating r = new Rating();
            Assert.AreEqual(r.GetHashCode(), r.Id);
        }
    }
}
