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
    public class TransactionServiceArgs : WitSessionServiceArgsBase
    {
        [DataMember(Order = 0)]
        Wit_Transaction Transaction;
        [DataMember(Order = 1)]
        public List<Wit_Item> Items;
        [DataMember(Order = 2)]
        public List<Wit_Table> Tables;
        [DataMember(Order = 3)]
        public List<KeyValuePair<int, string>> Status;

        public TransactionServiceArgs()
        { }
        public TransactionServiceArgs(string sessionID)
        {
            //Add Logic here
        }
    }
}