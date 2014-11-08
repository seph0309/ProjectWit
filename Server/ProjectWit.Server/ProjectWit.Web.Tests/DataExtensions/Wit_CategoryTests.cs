using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWit.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProjectWit.Model.Tests
{
    [TestClass()]
    public class Wit_CategoryTests
    {
        [TestMethod()]
        public void ToSerializableTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindByIdAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveAsyncTest()
        {
            Wit_Category cat = new Wit_Category();
            try
            {
                cat.RemoveAsync(new Guid("47DF81BC-D64E-E411-A417-D459F8E9FF23")).Wait();
            }
            catch (Exception e) { }
                Assert.Fail();
        }

        [TestMethod()]
        public void UpdateAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}
