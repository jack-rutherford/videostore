using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VideoStore.Utilities;
using Model;
using System.Collections.Generic;
using static Model.Rental;

namespace ModelTest
{
    [TestClass]
    public class RentalTests
    {
        [TestMethod]
        public void TestRentalDate()
        {
            Video video = new Video() { Id = 1 };
            Customer customer = new Customer() { EmailAddress = "jack.rutherford@hope.edu" };
            DateFactory.Mode = DateFactoryMode.Test;
            Rental rental = new Rental(customer, video);
            Assert.AreEqual(rental.RentalDate, DateFactory.CurrentDate);
        }

        [TestMethod]
        public void TestDueDate() 
        {
            DateFactory.Mode = DateFactoryMode.Test;
            //Should be 7 days after rental date
            Video video = new Video() { Id = 1 };
            Customer customer = new Customer() { EmailAddress = "jack.rutherford@hope.edu" };
            Rental r1 = new Rental(customer, video)
            {
                RentalDate = DateFactory.CurrentDate,
                Video = new Video() { Id = 1, NewArrival = false },
            };

            r1.DueDate = DateFactory.CurrentDate.AddDays(7);
            Console.WriteLine("Rental Date: " + r1.RentalDate);
            Console.WriteLine("Due Date: " + r1.DueDate);
            Assert.AreEqual(r1.RentalDate.AddDays(7), r1.DueDate);

            //New release is three days after rental date
            Video video2 = new Video() { Id = 2, NewArrival = true };
            Rental r2 = new Rental(customer, video2)
            {
                RentalDate = DateFactory.CurrentDate,
            };

            r2.DueDate = DateFactory.CurrentDate.AddDays(3);
            Console.WriteLine("Rental Date: " + r2.RentalDate);
            Console.WriteLine("Due Date: " + r2.DueDate);
            Assert.AreEqual(r2.RentalDate.AddDays(3), r2.DueDate);
            //Argument exception if due date is before rental date
            try
            {
                Video video3 = new Video() { Id = 1 };
                Customer customer3 = new Customer() { EmailAddress = "jack.rutherford@hope.edu" };
                Rental r3 = new Rental(customer3, video3)
                {
                    RentalDate = DateFactory.CurrentDate,
                    DueDate = DateFactory.CurrentDate.AddDays(-10),
                    Video = new Video() { Id = 3, NewArrival = true },
                };
                Assert.Fail("Due date is not before Rental Date so there was no exception thrown");
            }catch (Exception e) { }
        }

        [TestMethod]
        public void TestReturn()
        {
            Movie movie = new Movie()
            {
                Title = "Movie",
                Year = 2000
            };
            Video video = new Video()
            {
                Id = 1,
                Movie = movie,
            };
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                },
                EmailAddress = "jake@hope.edu"
            };
            Customer customer2 = new Customer()
            {
                Name = new Name()
                {
                    First = "Bruce",
                    Last = "Wayne"
                },
                EmailAddress = "Snake@hope.edu"
            };

            Rental rental = customer.Rent(video);

            Assert.AreEqual(rental.ReturnDate, null);

            rental.Return();

            movie.AddReservation(customer2);

            rental.Return();

            Assert.IsTrue(rental.ReturnDate.Equals(DateFactory.CurrentDate));

        }

        public Boolean TestEqualMethod(Rental r1, Rental r2)
        {
            return r1.Video.Equals(r2.Video) && r1.Customer.Equals(r2.Customer) && r1.RentalDate.Equals(r2.RentalDate);
        }

        [TestMethod]
        public void TestEqual()
        {
            Video video = new Video() { Id = 1 };
            Customer customer = new Customer() { EmailAddress = "jack.rutherford@hope.edu" };
            Rental r1 = new Rental(customer, video)
            {
                Video = video,
                Customer = customer,
                RentalDate= DateFactory.CurrentDate,
            };
            Rental r2 = new Rental(customer, video)
            {
                RentalDate = DateFactory.CurrentDate,
            };
            Assert.AreEqual(TestEqualMethod(r1, r2), r1.Equals(r2));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Video video = new Video() { Id = 1 };
            Customer customer = new Customer() { EmailAddress = "jack.rutherford@hope.edu" };
            Rental r1 = new Rental(customer, video)
            {
                RentalDate = DateFactory.CurrentDate,
            };
            Assert.AreEqual(r1.GetHashCode(), r1.Id);
        }
    }
}
