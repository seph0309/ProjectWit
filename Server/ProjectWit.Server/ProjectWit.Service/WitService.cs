using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Service.ServiceArguments;

namespace ProjectWit.Service
{
    public class WitService : IWitService, IRequireParameter
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

        //http://localhost:56401/witservice.svc/NewTransaction?sessionid=80DE087B-346F-E411-989A-0021CCC18CF4&tableID=47DF81BC-D64E-E411-A417-D459F8E9FF22&numberofguest=33&status=Open
        public TransactionServiceArgs NewTransaction(string sessionID, string tableID, int numberOfGuest, string status)
        {
            TransactionServiceArgs serviceArgs = new TransactionServiceArgs(sessionID);
            serviceArgs.NewTransaction(tableID, numberOfGuest, status);
            return serviceArgs;
        }

        //http://localhost:56401/witservice.svc/GetTransaction?SessionID=80DE087B-346F-E411-989A-0021CCC18CF4&TransacionID=95F8C250-6071-E411-BBC2-0021CCC18CF4
        public TransactionServiceArgs GetTransaction(string sessionID, string transactionID)
        {
            TransactionServiceArgs serviceArgs = new TransactionServiceArgs(sessionID);
            if (RequireParameter(transactionID).Count() > 0)
            {
                serviceArgs.LogMessage.Add("One or more parameters is required.");
                return serviceArgs;
            }
            serviceArgs.GetTransaction(transactionID);
            return serviceArgs;
        }
        //http://localhost:56401/witservice.svc/SetTransactionStatus?SessionID=80DE087B-346F-E411-989A-0021CCC18CF4&TransactionID=F0E2C3DB-3B71-E411-BBC2-0021CCC18CF4&Status=Closed
        public TransactionServiceArgs SetTransactionStatus(string sessionID, string transactionID, string status)
        {
            TransactionServiceArgs serviceArgs = new TransactionServiceArgs(sessionID);
            if (RequireParameter(transactionID, status).Count() > 0)
            {
                serviceArgs.LogMessage.Add("One or more parameters is required.");
                return serviceArgs;
            }
            serviceArgs.SetTransactionStatus(transactionID, status);
            return serviceArgs;
        }
        //http://localhost:56401/witservice.svc/SetTransactionStatus?SessionID=80DE087B-346F-E411-989A-0021CCC18CF4&TransactionID=F0E2C3DB-3B71-E411-BBC2-0021CCC18CF4&TableID=47DF81BC-D64E-E411-A417-D459F8E9FF22
        public TransactionServiceArgs SetTable(string sessionID, string transactionID, string tableID)
        {
            TransactionServiceArgs serviceArgs = new TransactionServiceArgs(sessionID);
            if (RequireParameter(transactionID, tableID).Count() > 0)
            {
                serviceArgs.LogMessage.Add("One or more parameters is required.");
                return serviceArgs;
            }
            serviceArgs.SetTable(transactionID, tableID);
            return serviceArgs;
        }

        //http://localhost:56401/witservice.svc/SetTransactionStatus?SessionID=80DE087B-346F-E411-989A-0021CCC18CF4&Count=9
        public TransactionServiceArgs SetGuestCount(string sessionID, string transactionID, int count)
        {
            TransactionServiceArgs serviceArgs = new TransactionServiceArgs(sessionID);
            if (RequireParameter(transactionID, count).Count() > 0)
            {
                serviceArgs.LogMessage.Add("One or more parameters is required.");
                return serviceArgs;
            }
            serviceArgs.SetGuestCount(transactionID, count);
            return serviceArgs;
        }

        public List<string> RequireParameter(params object[] parameters)
        {
            List<string> returnVal = new List<string>();
            for (int index = 0; index < parameters.Count(); index++ )
            {
                if (parameters[index] == null || string.IsNullOrEmpty(parameters[index].ToString().Trim()))
                    returnVal.Add(string.Format("Parameter is required. Check parameter"));
            }
            return returnVal;
        }
    }
}