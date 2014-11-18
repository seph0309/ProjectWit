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
        LoginServiceArgs NewTransaction(string sessionID, string tableID, string numberOfGuest);

    }
}
