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

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    /// <summary>
    /// Implementation is in ProjectWit.Web
    /// </summary>
    [ServiceContract(Namespace = "http://wittapps.com/WitService")]
    public interface IWitService : ILoginService
        //, ITransactionService
        //, IOrderService
    {
        #region Test Data HERE
        [OperationContract(Name = "GetListData")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<Wit_Company> GetListData(int value);

        [OperationContract(Name = "GetData")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Wit_Company GetData(int value);
        #endregion
    }
}