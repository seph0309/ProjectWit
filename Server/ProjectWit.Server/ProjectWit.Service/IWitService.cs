using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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
        string GetData(int value);
        
        [OperationContract]
        void Test();

        // TODO: Add your service operations here
    }

}