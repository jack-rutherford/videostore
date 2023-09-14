using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using VideoStore.Utilities;
using System.Linq;
using System.Collections.Generic;

namespace ModelTest
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void TestDateHired()
        {
            DateFactory.Mode = DateFactoryMode.Test;
            Employee employee = new Employee() { Name = new Name() { First = "Jack", Last = "Rutherford" } };
            Assert.AreEqual(employee.DateHired, DateFactory.CurrentDate);
        }

        [TestMethod]
        public void TestDateOfBirth() 
        {
            DateFactory.Mode = DateFactoryMode.Test;
            try
            {
                Employee employee = new Employee()
                {
                    Name = new Name() { First = "Jack", Last = "Rutherford" },
                    DateHired = DateFactory.CurrentDate,
                    DateOfBirth = DateFactory.CurrentDate.AddYears(-10),
                };
                Assert.Fail("A 10 year old employee cannot work due to child labor laws. Try again");
            } catch (Exception ex) { }
            
        }

        [TestMethod]
        public void TestPassword()
        {
            Employee emp = new Employee();
            try
            {
                emp.Password = "abc";
                Assert.Fail("Password that is too short and doesn't have a number or uppercase doesn't throw an exception");
            }
            catch (Exception e) { }

            try
            {
                emp.Password = "abc1";
                Assert.Fail("Password that is too short and doesn't have uppercase doesn't throw an exception");
            }
            catch (Exception e) { }

            try
            {
                emp.Password = "abC";
                Assert.Fail("Password that is too short and doesn't have a number doesn't throw an exception");
            }
            catch (Exception e) { }

            try
            {
                emp.Password = "abcdefg";
                Assert.Fail("Password that doesn't have a number or uppercase doesn't throw an exception");
            }
            catch (Exception e) { }

            try
            {
                emp.Password = "abcDefg";
                Assert.Fail("Password that doesn't have a number doesn't throw an exception");
            }
            catch (Exception e) { }

            try
            {
                emp.Password = "abcdefg1";
                Assert.Fail("Password that doesn't have uppercase doesn't throw an exception");
            }
            catch (Exception e) { }

            emp.Password = "abCdefg1";
            Assert.IsTrue(emp.Password.Any(char.IsUpper) && emp.Password.Any(char.IsNumber) && emp.Password.Any(char.IsLower));
        }

        [TestMethod]
        public void TestIsManager()
        {
            Employee employee = new Employee()
            {
                Name = new Name() { First = "Jack", Last = "Rutherford" },
            };
            employee.Store = new Store() { Managers = new List<Employee>() { employee } };
            Assert.IsTrue(employee.IsManager);
        }

        [TestMethod]
        public void TestSupervisor()
        {
            Employee employee1 = new Employee()
            {
                Name = new Name() { First = "Jack", Last = "Rutherford" },
            };
            Employee employee2 = new Employee()
            {
                Name = new Name() { First = "Tatiana", Last = "Beran" },
                Supervisor = employee1,
            };
            Assert.IsNull(employee1.Supervisor);
            Assert.AreEqual(employee2.Supervisor, employee1);
            try
            {
                employee1.Supervisor = employee1;
                Assert.Fail("Employee cannot be the supervisor of themselves");
            } catch (Exception e) { }
        }

        public Boolean TestEqualMethod(Employee e1, Employee e2)
        {
            return e1.Name.Equals(e2.Name) && e1.DateOfBirth.Equals(e2.DateOfBirth);
        }

        [TestMethod]
        public void TestEqual()
        {
            DateFactory.Mode = DateFactoryMode.Test;
            Employee employee1 = new Employee()
            {
                Name = new Name() { First = "Jack", Last = "Rutherford" },
                DateOfBirth = DateFactory.CurrentDate.AddYears(-20)
            };
            Employee employee2 = new Employee()
            {
                Name = new Name() { First = "Jack", Last = "Rutherford" },
                DateOfBirth = DateFactory.CurrentDate.AddYears(-20)
            };
            Assert.AreEqual(TestEqualMethod(employee1, employee2), employee1.Equals(employee2));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            DateFactory.Mode = DateFactoryMode.Test;
            Employee employee1 = new Employee()
            {
                Name = new Name() { First = "Jack", Last = "Rutherford" },
                DateOfBirth = DateFactory.CurrentDate.AddYears(-20)
            };
            Assert.AreEqual(employee1.GetHashCode(), employee1.Id);
        }
    }
}
