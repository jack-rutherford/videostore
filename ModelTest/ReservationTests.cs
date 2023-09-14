using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using VideoStore.Utilities;

namespace ModelTest
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void ReservationDate()
        {
            DateFactory.Mode = DateFactoryMode.Test;
            Reservation reservation = new Reservation() 
            { 
                ReservationDate = DateFactory.CurrentDate 
            };

            Assert.AreEqual(reservation.ReservationDate, DateFactory.CurrentDate);
        }
        public Boolean TestEqualMethod(Reservation r1, Reservation r2)
        {
            return r1.Movie.Equals(r2.Movie) && r1.Customer.Equals(r2.Customer);
        }

        [TestMethod]
        public void TestEqual()
        {
            Reservation r1 = new Reservation()
            {
                Movie = new Movie() { Title = "Star Wars", Year = 1977},
                Customer = new Customer() { EmailAddress = "jack.rutherford@hope.edu" },
            };
            Reservation r2 = new Reservation()
            {
                Movie = new Movie() { Title = "Star Wars", Year = 1977 },
                Customer = new Customer() { EmailAddress = "jack.rutherford@hope.edu" },
            };
            Assert.AreEqual(TestEqualMethod(r1, r2), r1.Equals(r2));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Reservation r1 = new Reservation()
            {
                Movie = new Movie() { Title = "Star Wars", Year = 1977 },
                Customer = new Customer() { EmailAddress = "jack.rutherford@hope.edu" },
            };
            Assert.AreEqual(r1.GetHashCode(), r1.Id);
        }
    }

}
