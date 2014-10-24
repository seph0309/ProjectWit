using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWit.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectWit.Web;
using ProjectWit.Service.ServiceArguments;

namespace ProjectWit.Web.Tests.WitServiceTest
{
    [TestClass]
    public class WitServiceTest
    {
        [TestMethod]
        public void TestSessionServiceBase()
        {
            WitService wt = new WitService();
            LoginServiceArgs args;
            args = wt.LoginByUser("SYSADMIN", "PASSWORD", "", "");
            args = wt.LoginByUser("SYSADMIN", "passworD", "Chrome", "Ipad");
            args = wt.LoginBySession("D697FE5C-E259-E411-9081-0021CCC18CF4");

 
        }
        [TestMethod]
        public void TestGUID()
        {
            bool isValid = false;
            //valid GUID
            isValid = Wit_Commons.IsStringGUID("3213213");

            isValid = Wit_Commons.IsStringGUID("D697FE5C-E259-E411-9081-0021CCC18CF4");

        }

         [TestMethod]
        public void TestSessionProcess()
        {
             //Test the process from creating session to terminating it
             WitService wt = new WitService();
             LoginServiceArgs args = new LoginServiceArgs();
            
             //Login 
             args= wt.LoginByUser("SYSADMIN", "password", "Chrome", "Ipad");
             if(args.IsAuthenticated)
             {
                 string _guid = args.SessionID.ToString();
                 string _invalidGuid = "WITTAPPS-APPS-APPS-APPS-0021CCC18CF4";
                 string _doesNotExistGuid = "D697FE5C-E259-E411-9081-0021CCC18CF4";
                 
                 //Check if session exist
                 args = wt.IsSessionActive(_guid);
                 //Negative test
                 args = wt.IsSessionActive(_invalidGuid);
                 //Does not exist
                 args = wt.IsSessionActive(_doesNotExistGuid);
                 
                 //Delete invalid session
                 args = wt.TerminateSession(_invalidGuid);
                 //Check sessionID does not exist
                 args = wt.TerminateSession(_doesNotExistGuid);
                 //Check sessionID does exist
                 args = wt.TerminateSession(_guid);
             }
        }
    }
}
