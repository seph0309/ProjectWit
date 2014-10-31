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
        public void TestGUID()
        {
            using (WitDbContext db = new WitDbContext())
            {
                var varr = db.Wit_Category.ToList();
            }

        }

         [TestMethod]
        public void TestSessionProcess()
        {
             //Test the process from creating session to terminating it
             WitService wt = new WitService();
             LoginServiceArgs args = new LoginServiceArgs();

             //Login 
             args = wt.LoginByUser("SYSADMIN", "password", "Chrome", "Ipad");
             args = wt.LoginByUser("ADMIN", "password", "Chrome", "Ipad");
             args = wt.LoginByUser("CREW", "password", "Chrome", "Ipad");
             args = wt.LoginByUser("CUSTOMER", "password", "Chrome", "Ipad");

             return;
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
