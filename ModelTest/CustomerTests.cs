using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using System.Linq;
using System.Collections;
using VideoStore.Utilities;
using System.Collections.Generic;

namespace ModelTest
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent",
                }
            };

            Assert.IsNotNull(customer.PreferredStores);
            Assert.AreEqual(0, customer.PreferredStores.Count);
        }

        [TestMethod]
        public void TestPassword() 
        {
            Customer c = new Customer();
            try
            {
                c.Password = "abc";
                Assert.Fail("Password that is too short and doesn't have a number or uppercase doesn't throw an exception");
            }
            catch (Exception e) { }

            try
            {
                c.Password = "abc1";
                Assert.Fail("Password that is too short and doesn't have uppercase doesn't throw an exception");
            }
            catch (Exception e) { }

            try
            {
                c.Password = "abC";
                Assert.Fail("Password that is too short and doesn't have a number doesn't throw an exception");
            }
            catch (Exception e) { }

            try
            {
                c.Password = "abcdefg";
                Assert.Fail("Password that doesn't have a number or uppercase doesn't throw an exception");
            }
            catch (Exception e) { }

            try
            {
                c.Password = "abcDefg";
                Assert.Fail("Password that doesn't have a number doesn't throw an exception");
            }
            catch (Exception e) { }

            try
            {
                c.Password = "abcdefg1";
                Assert.Fail("Password that doesn't have uppercase doesn't throw an exception");
            }
            catch (Exception e) { }

            c.Password = "abCdefg1";
            Assert.IsTrue(c.Password.Any(char.IsUpper) && c.Password.Any(char.IsNumber) && c.Password.Any(char.IsLower));
        }

        [TestMethod]
        public void TestFullName()
        {

            Customer c = new Customer()
            {
                Name = new Name()
                {
                    First = "Jack",
                    Last = "Rutherford",
                }
            };

            try
            {
                Assert.AreEqual(c.FullName, "JackRutherford", "Full name doesn't have a space in it");
            } catch(Exception e) { }

            Assert.AreEqual(c.FullName, c.Name.First + " " + c.Name.Last);

        }

        [TestMethod]
        public void TestLateRentals()
        {
            Customer c = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu"
            };

            //slighly newer video than test date
            Video vid2 = new Video() { Id = 2, PurchaseDate = DateFactory.TestDate };
            vid2.PurchaseDate.AddMonths(1);

            //rent the videos

            //test date video
            c.Rent(new Video() { Id = 1, PurchaseDate = DateFactory.TestDate });
            c.Rent(vid2);
            //video that should not be overdue
            c.Rent(new Video() { Id = 3, PurchaseDate = DateFactory.CurrentDate});

            //Do i have to sort the list? or is it already sorted???
        }

        [TestMethod]
        public void TestAddReservation()
        {
            //Check if movie gets added
            //Make Movie
            Movie movie = new Movie()
            {
                Id = 1,
                Title = "Star Wars",
            };
            //Make Customer
            Customer c = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu"
            };
            //Make new reservation with customer and movie
            Assert.IsFalse(movie.Reservations.Contains(c.Reservation));
            c.AddReservation(movie);
            Assert.IsTrue(movie.Reservations.Contains(c.Reservation));
        }

        [TestMethod]
        public void TestRent()
        {
            Customer c = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu"
            };
            Rental rental = new Rental()
            {
                Video = new Video() { Id = 1, },
                Customer = c,
                RentalDate = DateFactory.CurrentDate,

            };

            Assert.IsFalse(c.Rentals.Contains(rental));
            c.Rent(rental.Video);
            Assert.IsTrue(c.Rentals.Contains(rental));
        }

        [TestMethod]
        public void TestAllow()
        {
            CommunicationMethod method = new CommunicationMethod()
            {
                Name = "iMessage",
            };
            Customer c = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu"
            };

            Assert.IsFalse(method.Customers.Contains(c));
            c.Allow(method);
            Assert.IsTrue(method.Customers.Contains(c));
            //Do not allow foreign form of communication
            CommunicationMethod m2 = new CommunicationMethod() { Name = "Facebook" };
            Assert.IsFalse(m2.Customers.Contains(c));
        }

        [TestMethod]
        public void TestDeny()
        {
            CommunicationMethod method = new CommunicationMethod()
            {
                Name = "iMessage",
            };
            Customer c = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu"
            };

            //Customer is not in there yet
            Assert.IsFalse(method.Customers.Contains(c));
            c.Allow(method);
            //Test that customer is allowed communication method
            Assert.IsTrue(method.Customers.Contains(c));
            //Test that customer is removed from communication method
            c.Deny(method);
            Assert.IsFalse(method.Customers.Contains(c));
        }
    }
}
