using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWit.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProjectWit.Service.Tests
{
    [TestClass()]
    public class WitServiceTests
    {
        [TestMethod()]
        public void RequireParameterTest()
        {
            WitService ws = new WitService();
            string sessionID = "";
            string name = "";
            string lastName = "";
            List<string> returnVal = ws.RequireParameter(sessionID, name, lastName);
        }
    }
}
