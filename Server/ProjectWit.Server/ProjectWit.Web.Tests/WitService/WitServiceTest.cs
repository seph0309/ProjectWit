using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectWit.Service;
using ProjectWit.Service.ServiceArguments;

namespace ProjectWit.Web.Tests.WitService
{
    [TestClass]
    public class WitServiceTest
    {
        [TestMethod]
        public void TestSessionServiceBase()
        {
            LoginServiceArgs ser = new LoginServiceArgs("SYSADMIN", "PASSWORD", "", "");

            LoginServiceArgs ser2 = new LoginServiceArgs("SYSADMIN", "password", "", "");
        }
    }
}
