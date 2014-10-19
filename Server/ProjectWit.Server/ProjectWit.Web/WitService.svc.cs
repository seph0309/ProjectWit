using ProjectWit.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using ProjectWit.Model;
using ProjectWit.Service.ServiceArguments;

namespace ProjectWit.Web
{
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WitService : WitServiceBase, IWitService 
    {
      
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        // Add more operations here and mark them with [OperationContract]

        public List<Wit_Company> GetListData(int value)
        {
            List<Wit_Company> comp = new List<Wit_Company>();
            comp.Add(new Wit_Company { CompanyName = "SephSample", CompanyNumber = "12345" });
            comp.Add(new Wit_Company { CompanyName = "SephSample", CompanyNumber = "12345" });
            comp.Add(new Wit_Company { CompanyName = "SephSample", CompanyNumber = "12345" });
            return comp;
        }

        public Wit_Company GetData(int value)
        {
            return new Wit_Company { CompanyName = "SephSample", CompanyNumber = "12345" };
        }


        /// <summary>
        /// Authenticates the user and returns Session ID and Categories/Items list
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LoginServiceArgs Login(string userName, string password, string browser, string deviceType)
        {
            LoginServiceArgs serviceArgs = new LoginServiceArgs(userName, password, browser, deviceType);

            return serviceArgs; 
        }
    }
}
