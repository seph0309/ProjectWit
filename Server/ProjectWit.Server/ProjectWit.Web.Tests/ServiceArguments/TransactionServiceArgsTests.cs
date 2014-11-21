using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWit.Service.ServiceArguments;
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
            TransactionServiceArgs srvcArgs = new TransactionServiceArgs(sessionId);
            //srvcArgs.GetTransaction(sessionId, transactionID, "Open");
        }

        [TestMethod()]
        public void NewTransactionTest()
        {
            Guid tableID = new Guid("47DF81BC-D64E-E411-A417-D459F8E9FF22");
            string sessionID = "";
            TransactionServiceArgs srvcArgs = new TransactionServiceArgs(sessionID);
            //srvcArgs.NewTransaction(sessionID, tableID.ToString(),3,"Open");
        }
    }
}
