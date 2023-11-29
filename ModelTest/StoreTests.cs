using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using VideoStore.Utilities;
using System.Collections.Generic;

namespace ModelTest
{
    [TestClass]
    public class StoreTests
    {
        [TestMethod]
        public void TestRemoveManager()
        {
            DateFactory.Mode = DateFactoryMode.Test;
            Employee employee1 = new Employee()
            {
                Name = new Name() { First = "Jack", Last = "Rutherford" },
            };
            Store store = new Store()
            {
                StreetAddress = "2979",
                ZipCode = new ZipCode() { Code = "49424"},
                Managers = new List<Employee>() { employee1 }
            };
            Assert.IsNotNull(store.Managers);
            Assert.IsTrue(store.Managers.Contains(employee1));
            //Remove manager
            store.RemoveManager(employee1);
            Assert.IsFalse(store.Managers.Contains(employee1));
        }

        [TestMethod]
        public void TestAddVideo() 
        {
            Store store = new Store()
            {
                StreetAddress = "2979",
                ZipCode = new ZipCode() { Code = "49424" },
            };

            Video video = new Video()
            {
                Id = 1,
            };

            Assert.IsFalse(store.Videos.Contains(video));
            //Add video
            store.AddVideo(video);
            Assert.IsTrue(store.Videos.Contains(video));
        }

        [TestMethod]
        public void TestRemoveVideo()
        {

            Store store = new Store()
            {
                StreetAddress = "2979",
                ZipCode = new ZipCode() { Code = "49424", City = "San Antonio", State = "Texas" },
                Videos = new List<Video>() { },
            };

            Video video = new Video()
            {
                Id = 1,
                Store = store
            };

            store.AddVideo(video);

            
            bool res = false;
            foreach (Video v in store.Videos)
            {
                if (v.Equals(video))
                {
                    res = true;
                    break;
                }
            }
            Assert.IsTrue(res);
            res = false;
            store.RemoveVideo(video);
            foreach (Video v in store.Videos)
            {
                if (v.Equals(video))
                {
                    res = true;
                    break;
                }
            }
            Assert.IsFalse(res);
        }

        public Boolean TestEqualMethod(Store s1, Store s2)
        {
            return s1.StreetAddress.Equals(s2.StreetAddress) && s1.ZipCode.Equals(s2.ZipCode);
        }

        [TestMethod]
        public void TestEqual()
        {
            Store s1 = new Store()
            {
                StreetAddress = "2979",
                ZipCode = new ZipCode() { Code = "49424" },
            };
            Store s2 = new Store()
            {
                StreetAddress = "2979",
                ZipCode = new ZipCode() { Code = "49424" },
            };
            Assert.AreEqual(TestEqualMethod(s1, s2), s1.Equals(s2));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Store s1 = new Store()
            {
                StreetAddress = "2979",
                ZipCode = new ZipCode() { Code = "49424" },
            };
            Assert.AreEqual(s1.GetHashCode(), s1.Id);
        }
    }
}
