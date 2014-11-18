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
    public interface ILoginService
    {
        [OperationContract(Name = "LoginByUser")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        LoginServiceArgs LoginByUser(string userName, string password, string browser, string deviceType);

        [OperationContract(Name = "LoginBySession")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        LoginServiceArgs LoginBySession(string sessionID);

        [OperationContract(Name = "TerminateSession")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        LoginServiceArgs TerminateSession(string sessionID);

        [OperationContract(Name = "IsSessionActive")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        LoginServiceArgs IsSessionActive(string sessionID); 
    }
}
