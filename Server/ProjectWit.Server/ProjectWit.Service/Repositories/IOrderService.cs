﻿using System;
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

        [OperationContract(Name = "NewOrder")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        OrderServiceArgs NewOrder(string sessionID, string transactionID, string itemID, int quantity, string status);

        [OperationContract(Name = "SetOrderStatus")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        OrderServiceArgs SetOrderStatus(string sessionID, string orderID, string orderStatus);

        [OperationContract(Name = "SetOrderQuantity")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        OrderServiceArgs SetOrderQuantity(string sessionID, string orderID, int quantity);
    }
}
