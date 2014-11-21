using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ProjectWit.Model;
using ProjectWit.Service.ServiceArguments;

namespace ProjectWit.Service
{
    [ServiceContract]
    public interface ITransactionService
    {
        [OperationContract(Name = "NewTransaction")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        TransactionServiceArgs NewTransaction(string sessionID, string tableID, int numberOfGuest, string status);

        [OperationContract(Name = "GetTransaction")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        TransactionServiceArgs GetTransaction(string sessionID, string transactionID);

        [OperationContract(Name = "SetTransactionStatus")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        TransactionServiceArgs SetTransactionStatus(string sessionID, string transactionID, string status);

        [OperationContract(Name = "SetTable")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        TransactionServiceArgs SetTable(string sessionID, string transactionID, string tableID);

        [OperationContract(Name = "SetGuestCount")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        TransactionServiceArgs SetGuestCount(string sessionID, string transactionID, int count);
    }
}
