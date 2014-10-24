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

            //Invalid GUID


        }
    }
}
