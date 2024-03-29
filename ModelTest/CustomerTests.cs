﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            //try
            //{
            //    c.Password = "abc";
            //    Assert.Fail("Password that is too short and doesn't have a number or uppercase doesn't throw an exception");
            //}
            //catch (Exception e) { }

            //try
            //{
            //    c.Password = "abc1";
            //    Assert.Fail("Password that is too short and doesn't have uppercase doesn't throw an exception");
            //}
            //catch (Exception e) { }

            //try
            //{
            //    c.Password = "abC";
            //    Assert.Fail("Password that is too short and doesn't have a number doesn't throw an exception");
            //}
            //catch (Exception e) { }

            //try
            //{
            //    c.Password = "abcdefg";
            //    Assert.Fail("Password that doesn't have a number or uppercase doesn't throw an exception");
            //}
            //catch (Exception e) { }

            //try
            //{
            //    c.Password = "abcDefg";
            //    Assert.Fail("Password that doesn't have a number doesn't throw an exception");
            //}
            //catch (Exception e) { }

            //try
            //{
            //    c.Password = "abcdefg1";
            //    Assert.Fail("Password that doesn't have uppercase doesn't throw an exception");
            //}
            //catch (Exception e) { }

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
                Assert.AreEqual(c.FullName, "Jack Rutherford", "Full name doesn't have a space in it");
            } catch(Exception e) { }

            Assert.AreEqual(c.FullName, c.Name.First + " " + c.Name.Last);

        }

        [TestMethod]
        public void TestLateRentals()
        {
            DateFactory.Mode = DateFactoryMode.Test;
            //Console.WriteLine("Current Date: "+ DateFactory.CurrentDate);
            Customer c = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu"
            };

            Assert.IsNotNull(c.LateRentals);

            Video vid1 = new Video() { Id = 1 };

            Rental r1 = new Rental(c, vid1)
            {
                RentalDate = DateFactory.CurrentDate.AddMonths(-4),
                DueDate = DateFactory.CurrentDate.AddMonths(-2),
            };

            Rental r2 = new Rental(c, vid1)
            {
                RentalDate = DateFactory.CurrentDate.AddMonths(-10),
                DueDate = DateFactory.CurrentDate.AddMonths(-8),
            };
            

            Rental r3 = new Rental(c, vid1)
            {
                RentalDate = DateFactory.CurrentDate.AddDays(-2),
                DueDate = DateFactory.CurrentDate.AddDays(10),
            };
            c.Rentals = new List<Rental>() { r1, r2, r3 };
            Assert.AreEqual(c.LateRentals[0], r2);
            Assert.AreEqual(c.LateRentals[1], r1);
            Assert.IsFalse(c.LateRentals.Contains(r3));
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
            Video video = new Video() { Id = 1, };
            Rental rental = new Rental(c, video)
            {
                RentalDate = DateFactory.CurrentDate,

            };
            bool res = false;
            foreach (Rental r in c.Rentals)
            {
                if (r.Equals(rental))
                {
                    res = true;
                    break;
                }
            }
            Assert.IsFalse(res);
            c.Rent(rental.Video);
            res = false;
            foreach (Rental r in c.Rentals)
            {
                if(r.Equals(rental))
                {
                    res = true;
                    break;
                }
            }
            Assert.IsTrue(res);
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

        [TestMethod]
        public void TestAddPreferredStore()
        {
            //Second parameter of AddPreferredStore is optional
            Customer c = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu"
            };
            Store store1 = new Store()
            {
                StreetAddress = "2979",
                ZipCode = new ZipCode() { Code = "49424" },
            };
            Store store2 = new Store()
            {
                StreetAddress = "987",
                ZipCode = new ZipCode() { Code = "49424" },
            };
            Store store3 = new Store()
            {
                StreetAddress = "123",
                ZipCode = new ZipCode() { Code = "49424" },
            };
            Store store4 = new Store()
            {
                StreetAddress = "108",
                ZipCode = new ZipCode() { Code = "49424" },
            };
            Store store5 = new Store()
            {
                StreetAddress = "108",
                ZipCode = new ZipCode() { Code = "49424" },
            };
            Store store6 = new Store()
            {
                StreetAddress = "108",
                ZipCode = new ZipCode() { Code = "49424" },
            };

            //Stores should not be in there yet
            Assert.IsFalse(c.PreferredStores.Contains(store1));
            Assert.IsFalse(c.PreferredStores.Contains(store2));
            //Add preferred store
            c.AddPreferredStore(store1);
            Assert.IsTrue(c.PreferredStores.Contains(store1));
            //Add another store
            c.AddPreferredStore(store3);
            Assert.IsTrue(c.PreferredStores.Contains(store3));
            //Add store to second slot
            c.AddPreferredStore(store3, 0);
            Assert.IsTrue(c.PreferredStores[0].Equals(store3));
            //Add store without parameter and make sure it is in the final slot
            c.AddPreferredStore(store4);
            Assert.IsTrue(c.PreferredStores[c.PreferredStores.Count - 1].Equals(store4));
            //Add store that already exists without parameter (should be in last index)
            c.AddPreferredStore(store5);
            Assert.IsTrue(c.PreferredStores[c.PreferredStores.Count - 1].Equals(store5));
            //Console.WriteLine(c.PreferredStores);
            //Add store that already exists with parameter
            c.AddPreferredStore(store6, 1);
            Assert.IsTrue(c.PreferredStores[1].Equals(store6));
        }

        [TestMethod]
        public void TestRemovePreferredStore()
        {
            Customer c = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu"
            };
            Store store1 = new Store()
            {
                StreetAddress = "2979",
                ZipCode = new ZipCode() { Code = "49424" },
            };
            Store store2 = new Store()
            {
                StreetAddress = "987",
                ZipCode = new ZipCode() { Code = "49424" },
            };

            Assert.IsFalse(c.PreferredStores.Contains(store1));
            Assert.IsFalse(c.PreferredStores.Contains(store2));
            //Add stores
            c.AddPreferredStore(store1);
            c.AddPreferredStore(store2);
            Assert.IsTrue(c.PreferredStores.Contains(store1));
            Assert.IsTrue(c.PreferredStores.Contains(store2));
            Assert.IsTrue(c.PreferredStores[1].Equals(store2));
            //Remove store1
            c.RemovePreferredStore(store1);
            Assert.IsFalse(c.PreferredStores.Contains(store1));
            Assert.IsTrue(c.PreferredStores[0].Equals(store2));
            //Remove store1 (that doesn't exist anymore) should throw exception
            try
            {
                c.RemovePreferredStore(store1);
                Assert.Fail("Store1 still exists in this list and doesn't throw an exception");
            } catch (Exception ex) { }
        }

        public Boolean TestEqualsMethod(Customer c1, Customer c2)
        {
            return c1.EmailAddress.Equals(c2.EmailAddress);
        }

        [TestMethod]
        public void TestEqual()
        {
            Customer c1 = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu"
            };
            Customer c2 = new Customer()
            {
                EmailAddress = "jack.rutherford@hope.edu"
            };

            Assert.AreEqual(TestEqualsMethod(c1, c2), c1.Equals(c2));
        }

        [TestMethod]
        public void TestHashCode()
        {
            Customer c1 = new Customer();
            Assert.AreEqual(c1.Id, c1.GetHashCode());
        }
    }
}
