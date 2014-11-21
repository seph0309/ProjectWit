using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWit.Service.ServiceArguments;
using ProjectWit.Service;
using ProjectWit.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProjectWit.Service.ServiceArguments.Tests
{
    [TestClass()]
    public class TransactionServiceArgsTests
    {
        [TestMethod()]
        public void GetTransactionTest()
        {
            string sessionId = "";
            string transactionID = ""; 
            TransactionServiceArgs srvcArgs = new TransactionServiceArgs();
            srvcArgs.GetTransaction(sessionId, transactionID);
        }

        [TestMethod()]
        public void NewTransactionTest()
        {
         
        }
    }
}
