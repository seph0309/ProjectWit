﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ProjectWit.Model;

namespace ProjectWit.Service
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    /// <summary>
    /// Implementation is in ProjectWit.Web
    /// </summary>
    [ServiceContract(Namespace = "http://wittapps.com/WitService")]
    public interface IWitService : ILoginService, ITransactionService , IOrderService
    {
        /// <summary>
        /// Use this to initialize the service for the first time and for faster loading in next transactions.
        /// May be called async
        /// </summary>
        [OperationContract(Name = "InitializeWitService")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        void InitializeWitService();
    }
}