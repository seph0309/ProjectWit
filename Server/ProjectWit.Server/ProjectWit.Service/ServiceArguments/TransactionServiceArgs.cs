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
    public class TransactionServiceArgs : WitSessionServiceArgsBase , ITransactionService
    {
        [DataMember(Order = 0)]
        Wit_Transaction Transaction;
        [DataMember(Order = 1)]
        public List<Wit_Item> Items;
        [DataMember(Order = 2)]
        public List<Wit_Table> Tables;
        [DataMember(Order = 3)]
        public List<KeyValuePair<int, string>> Status;

        private IWit_Transaction ITransaction;

        public TransactionServiceArgs()
        {
            Transaction = new Wit_Transaction();
        }
        public TransactionServiceArgs(IWit_Transaction itrans)
        {
            //Add Logic here
            ITransaction = itrans;
            ITransaction.SetDbContext(new WitServiceDBContext());
            Transaction = new Wit_Transaction();
        }

        public TransactionServiceArgs NewTransaction(string sessionID, string tableID, int numberOfGuest)
        {
            Transaction.Table_UID = new Guid(tableID);
            Transaction.NumberOfGuest = numberOfGuest;
            Transaction.Status = "Open";
            ITransaction.CreateAsync(Transaction, "gg").Wait();
            
         
            return this;
        }

        public TransactionServiceArgs GetTransaction(string sessionID, string transactionID)
        {
            Transaction = ITransaction.FindByIdAsync(new Guid(transactionID)).Result;
 
            return this;
        }

        public TransactionServiceArgs SetTransactionStatus(string sessionID, string transactionID, string status)
        {
            return this;
        }

        public TransactionServiceArgs ChangeTable(string sessionID, string transactionID, string tableID)
        {
            return this;
        }

        public TransactionServiceArgs UpdateGuestCount(string sessionID, string transactionID, int count)
        {
            return this;
        }
    }
}