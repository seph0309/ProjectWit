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
        TransactionServiceArgs NewTransaction(string sessionID, string tableID, int numberOfGuest);

        [OperationContract(Name = "GetTransaction")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        TransactionServiceArgs GetTransaction(string sessionID, string transactionID);

        [OperationContract(Name = "SetTransactionStatus")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        TransactionServiceArgs SetTransactionStatus(string sessionID, string transactionID, string status);

        [OperationContract(Name = "ChangeTable")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        TransactionServiceArgs ChangeTable(string sessionID, string transactionID, string tableID);

        [OperationContract(Name = "UpdateGuestCount")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        TransactionServiceArgs UpdateGuestCount(string sessionID, string transactionID, int count);
    }
}
