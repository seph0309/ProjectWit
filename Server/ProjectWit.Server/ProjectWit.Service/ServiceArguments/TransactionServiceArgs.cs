using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ProjectWit.Service.ServiceArguments
{
    [DataContract]
    public class TransactionServiceArgs : WitSessionServiceArgs
    {
        [DataMember(Order = 0)]
        Wit_Transaction Transaction = new Wit_Transaction();
        [DataMember(Order = 1)]
        public List<Wit_Item> Items;
        [DataMember(Order = 2)]
        public List<Wit_Table> Tables;
        [DataMember(Order = 3)]
        public List<KeyValuePair<int, string>> Status;

        private IWit_Transaction ITransaction;

        public TransactionServiceArgs(string sessionID) : base(sessionID)
        {
            ITransaction = new Wit_Transaction();
            ITransaction.SetDbContext(new WitServiceDBContext(SessionID.ToString()));
        }
 

        public void NewTransaction(string tableID, int numberOfGuest, string status)
        {
            Transaction.Table_UID = new Guid(tableID);
            Transaction.NumberOfGuest = numberOfGuest;
            Transaction.Status = status;
            ITransaction.CreateAsync(Transaction, SessionID.ToString()).Wait();
            
        }

        
        public void GetTransaction(string transactionID)
        {
            if(String.IsNullOrEmpty(transactionID))
            {
                LogMsg("TransactionID is required");
                return;
            }
            Transaction = ITransaction.FindByIdAsync(new Guid(transactionID)).Result;
            if (Transaction == null)
                LogMsg("Transaction not found");
        }

        public void SetTransactionStatus(string transactionID, string status)
        {
            Transaction = ITransaction.SetTransactionStatus(transactionID, status);
        }

        public void SetTable(string transactionID, string tableID)
        {
            Transaction = ITransaction.SetTable(transactionID, tableID);
        }

        public void SetGuestCount(string transactionID, int count)
        {
            Transaction = ITransaction.SetGuestCount(transactionID, count);
        }
    }
}