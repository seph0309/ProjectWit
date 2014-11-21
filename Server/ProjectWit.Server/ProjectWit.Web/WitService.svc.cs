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
    public class WitService : IWitService
    {

        /// <summary>
        /// Authenticates the user and returns Session ID and Categories/Items list
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LoginServiceArgs LoginByUser(string userName, string password, string browser, string deviceType)
        {
            LoginServiceArgs serviceArgs = new LoginServiceArgs(userName, password, browser, deviceType);
            return serviceArgs; 
        }

        /// <summary>
        /// Authenticates using SessionUID
        /// </summary>
        /// <param name="sessionUID"></param>
        /// <returns></returns>
        public LoginServiceArgs LoginBySession(string sessionID)
        {
            LoginServiceArgs serviceArgs = new LoginServiceArgs(sessionID);
            return serviceArgs;
        }

        public LoginServiceArgs TerminateSession(string sessionID)
        {
            LoginServiceArgs serviceArgs = new LoginServiceArgs();
            serviceArgs.TerminateSession(sessionID);
            return serviceArgs;
        }

        public LoginServiceArgs IsSessionActive(string sessionID)
        {
            LoginServiceArgs serviceArgs = new LoginServiceArgs();
            serviceArgs.IsSessionActive(sessionID);
            return serviceArgs;
        }

        public TransactionServiceArgs NewTransaction(string sessionID, string tableID, int numberOfGuest)
        {
            TransactionServiceArgs serviceArgs = new TransactionServiceArgs();
            serviceArgs.NewTransaction(sessionID, tableID, numberOfGuest);
            return serviceArgs;
        }


        public TransactionServiceArgs GetTransaction(string sessionID, string transactionID)
        {
            TransactionServiceArgs serviceArgs = new TransactionServiceArgs();
            return serviceArgs;
        }

        public TransactionServiceArgs SetTransactionStatus(string sessionID, string transactionID, string status)
        {
            TransactionServiceArgs serviceArgs = new TransactionServiceArgs();
            return serviceArgs;
        }

        public TransactionServiceArgs ChangeTable(string sessionID, string transactionID, string tableID)
        {
            TransactionServiceArgs serviceArgs = new TransactionServiceArgs();
            return serviceArgs;
        }

        public TransactionServiceArgs UpdateGuestCount(string sessionID, string transactionID, int count)
        {
            TransactionServiceArgs serviceArgs = new TransactionServiceArgs();
            return serviceArgs;
        }
    }
}
