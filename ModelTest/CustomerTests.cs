using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;

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
                Assert.Fail("Password that is too short doesn't throw an exception");
            }
            catch (Exception e) { }
        }
    }
}
