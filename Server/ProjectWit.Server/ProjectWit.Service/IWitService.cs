using System;
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
    [ServiceContract]
    public interface IWitService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<Wit_Company> GetData(int value);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        bool Login(string userName, string password);
        
        [OperationContract]
        void Test();

        // TODO: Add your service operations here
    }

}