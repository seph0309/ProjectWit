﻿using System;
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
         
        }
    }
}