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
    public class Wit_TransactionTests
    {
        private Wit_Transaction wit_Transaction = new Wit_Transaction();
        
        [TestMethod()]
        public void ToSerializableTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetByIdAsyncTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void FindByIdAsyncTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllAsyncTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateAsyncTest()
        {
            //wit_Transaction.CreateAsync(new Wit_Transaction
            //{
            //    Status = Wit_Status.Open,
            //    Table_UID = new Guid("47DF81BC-D64E-E411-A417-D459F8E9FF21"),
            //    Wit_Order =

            //}, "Test");
        }

        [TestMethod()]
        public void RemoveAsyncTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateAsyncTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            throw new NotImplementedException();
        }
    }
}
