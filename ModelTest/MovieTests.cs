using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using System.Collections.Generic;
using VideoStore.Utilities;

namespace ModelTest
{
    [TestClass]
    public class MovieTests
    {
        Movie movie1 = new Movie()
        {
            Title = "Star Wars",
            Year = 1979,
            Reservations = new List<Reservation> {
                    new Reservation() { ReservationDate = new DateTime(1980, 1, 1, 0, 0, 0) },
                    new Reservation() { ReservationDate = new DateTime(1981, 1, 1, 0, 0, 0) },
                    new Reservation() { ReservationDate = new DateTime(1982, 1, 1, 0, 0, 0) },
                    new Reservation() { ReservationDate = new DateTime(1983, 1, 1, 0, 0, 0) }
                }
        };

        Movie movie2 = new Movie()
        {
            Title = "Star Wars",
            Year = 1979,
            Reservations = new List<Reservation> {
                    new Reservation() { ReservationDate = new DateTime(1990, 1, 1, 0, 0, 0) },
                    new Reservation() { ReservationDate = new DateTime(1993, 1, 1, 0, 0, 0) },
                    new Reservation() { ReservationDate = new DateTime(1996, 1, 1, 0, 0, 0) },
                    new Reservation() { ReservationDate = new DateTime(1998, 1, 1, 0, 0, 0) }
                }
        };

        Movie movie3 = new Movie()
        {
            Title = "Star Wars",
            Year = 1979,
            Reservations = new List<Reservation> {
                    new Reservation() { ReservationDate = new DateTime(1990, 1, 1, 0, 0, 0) },
                    new Reservation() { ReservationDate = new DateTime(1983, 1, 1, 0, 0, 0) },
                    new Reservation() { ReservationDate = new DateTime(1996, 1, 1, 0, 0, 0) },
                    new Reservation() { ReservationDate = new DateTime(1995, 1, 1, 0, 0, 0) }
                }
        };

        [TestMethod]
        public void TestReservations()
        {
            Assert.IsNotNull(movie1.Reservations, "Movie Reservation list is null");
            Boolean result1 = true;
            for (var i = 0; i < movie1.Reservations.Count-1; i++)
            {
                if (movie1.Reservations[i].ReservationDate > movie1.Reservations[i + 1].ReservationDate)
                {
                    result1 = false; break;
                }
            }
            Assert.IsTrue(result1, "Movie 1 List reservation dates out of order");

            Boolean result2 = true;
            for (var i = 0; i < movie3.Reservations.Count - 1; i++)
            {
                if (movie3.Reservations[i].ReservationDate > movie3.Reservations[i + 1].ReservationDate)
                {
                    result2 = false; break;
                }
            }
            Assert.IsFalse(result2, "Movie 3 List reservation dates are in order (they should not be)");
        }

        [TestMethod]
        public void TestEqual()
        {
            Boolean result = true;

            if ((movie1.Title == null) && (movie2.Title != null)) result = false;
            
            if(!movie1.Year.Equals(movie2.Year)) result = false;

            if(!movie1.Title.Equals(movie2.Title)) result = false;

            if (movie1.Year.Equals(movie2.Year) && movie1.Title.Equals(movie2.Title)) result = true;

            Assert.IsTrue(result, "Items are not equal");
        }

        [TestMethod]
        public void TestHashCode()
        {
            Assert.AreEqual(movie1.GetHashCode(), movie1.Id);
        }
    }
}
