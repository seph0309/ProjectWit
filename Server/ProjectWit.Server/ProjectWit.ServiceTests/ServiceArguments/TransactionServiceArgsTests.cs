using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWit.Service.ServiceArguments;
using ProjectWit.Service;
using ProjectWit.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
namespace ProjectWit.Service.ServiceArguments.Tests
{
    [TestClass()]
    public class TransactionServiceArgsTests
    {
        [TestMethod()]
        public void GetTransactionTest()
        {
            string sessionId = "";
            string transactionID = "F0E2C3DB-3B71-E411-BBC2-0021CCC18CF4";
            TransactionServiceArgs srvcArgs = new TransactionServiceArgs(sessionId);
            srvcArgs.GetTransaction(transactionID);
            Debug.WriteLine(srvcArgs);
            
        }

        [TestMethod()]
        public void NewTransactionTest()
        {
            Wit_Transaction trans = new Wit_Transaction();
            IWit_Transaction ITrans = new Wit_Transaction();
            IWit_Transaction ITrans2 = new Wit_Transaction();

            trans.Transaction_UID = new Guid("B71B2DBE-1975-E411-84BB-0021CCC18CF6");
            var entity = ITrans.GetByIdAsync(trans.Transaction_UID).Result;
            var entity2 = ITrans2.FindByIdAsync(trans.Transaction_UID).Result;
            ITrans = new Wit_Transaction();
            Debug.WriteLine(ITrans.LogMessage);
        }
    }
}
