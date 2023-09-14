using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VideoStore.Utilities;
using Model;
using System.Collections.Generic;

namespace ModelTest
{
    [TestClass]
    public class RentalTests
    {
        [TestMethod]
        public void TestRentalDate()
        {
            DateFactory.Mode = DateFactoryMode.Test;
            Rental rental = new Rental();
            Assert.AreEqual(rental.RentalDate, DateFactory.CurrentDate);
        }

        [TestMethod]
        public void TestDueDate() 
        {
            DateFactory.Mode = DateFactoryMode.Test;
            //Should be 7 days after rental date
            Rental r1 = new Rental()
            {
                RentalDate = DateFactory.CurrentDate,
                Video = new Video() { Id = 1, NewArrival = false },
            };

            r1.DueDate = DateFactory.CurrentDate.AddDays(7);
            Console.WriteLine("Rental Date: " + r1.RentalDate);
            Console.WriteLine("Due Date: " + r1.DueDate);
            Assert.AreEqual(r1.RentalDate.AddDays(7), r1.DueDate);

            //New release is three days after rental date
            Rental r2 = new Rental()
            {
                RentalDate = DateFactory.CurrentDate,
                Video = new Video() { Id = 2, NewArrival = true },
            };

            r2.DueDate = DateFactory.CurrentDate.AddDays(3);
            Console.WriteLine("Rental Date: " + r2.RentalDate);
            Console.WriteLine("Due Date: " + r2.DueDate);
            Assert.AreEqual(r2.RentalDate.AddDays(3), r2.DueDate);
            //Argument exception if due date is before rental date
            try
            {
                Rental r3 = new Rental()
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
            DateFactory.Mode = DateFactoryMode.Test;
            Store store = new Store() { StreetAddress = "2979", ZipCode = new ZipCode() { Code = "49424" } };
            Video video1 = new Video() { Id = 1, Movie = new Movie() { Title = "Star Wars", Year = 1976} };
            Customer customer1 = new Customer() 
            { 
                EmailAddress = "jack.rutherford@hope.edu", 
                PreferredStores = new List<Store>() { store },
            };
            Rental rental = new Rental()
            {
                Customer = customer1,
                Video = video1,
                RentalDate = DateFactory.CurrentDate
            };

            customer1.Rent(video1);
            ReturnReceipt rr1 = rental.Return();
            Assert.AreEqual(rental.ReturnDate, DateFactory.CurrentDate);
            Assert.IsNull(rr1);

            DateFactory.Mode = DateFactoryMode.Test;
            Customer customer2 = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu",
                PreferredStores = new List<Store>() { store },
            };
            store.AddVideo(video1);
            Video video2 = new Video() { Id = 1, Movie = new Movie() { Title = "Star Wars", Year = 1976 }, Store = store };
            Rental rental2 = new Rental()
            {
                Customer = customer2,
                Video = video2,
                RentalDate = DateFactory.CurrentDate
            };
            video2.Movie.AddReservation(customer2);
            customer2.Rent(video2);
            ReturnReceipt rr2 = rental.Return();
            //Assert.AreEqual(rental2.ReturnDate, DateFactory.CurrentDate);
            //Assert.IsNotNull(rr2);
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
            Rental r1 = new Rental()
            {
                Video = video,
                Customer = customer,
                RentalDate= DateFactory.CurrentDate,
            };
            Rental r2 = new Rental()
            {
                Video = video,
                Customer = customer,
                RentalDate = DateFactory.CurrentDate,
            };
            Assert.AreEqual(TestEqualMethod(r1, r2), r1.Equals(r2));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Video video = new Video() { Id = 1 };
            Customer customer = new Customer() { EmailAddress = "jack.rutherford@hope.edu" };
            Rental r1 = new Rental()
            {
                Video = video,
                Customer = customer,
                RentalDate = DateFactory.CurrentDate,
            };
            Assert.AreEqual(r1.GetHashCode(), r1.Id);
        }
    }
}
