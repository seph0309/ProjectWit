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
    public interface IOrderService
    {
        [OperationContract(Name = "GetOrders")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        OrderServiceArgs GetOrders(string sessionID, string transactionID);

        [OperationContract(Name = "SaveOrders")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        OrderServiceArgs SaveOrders(string sessionID, string transactionID);

        [OperationContract(Name = "SetStatus")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        OrderServiceArgs SetStatus(string sessionID, string transactionID, string status);
    }
}
