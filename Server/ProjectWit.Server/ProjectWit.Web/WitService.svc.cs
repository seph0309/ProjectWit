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

namespace ProjectWit.Web
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WitService : WitServiceBase, IWitService 
    {
      
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        // Add more operations here and mark them with [OperationContract]

        public Wit_Company GetData(int value)
        {
            return new Wit_Company{ CompanyName = "SephSample", CompanyNumber = "12345" };
        }

        public void Test()
        {
            throw new NotImplementedException();
        }


        public bool Login(string userName, string password)
        {
            return LoginUser(userName, password);
        }
    }
}
