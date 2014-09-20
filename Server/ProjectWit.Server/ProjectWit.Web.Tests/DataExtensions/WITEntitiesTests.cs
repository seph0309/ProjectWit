using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWit.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProjectWit.Model.Tests
{
    [TestClass()]
    public class WITEntitiesTests
    {
        [TestMethod()]
        public void GetUsersTest()
        {
            using (WITEntities db = new WITEntities())
            {
                List<Wit_User> user = new List<Wit_User>();
                user = db.GetUsers();
            }
            Assert.IsTrue(true);
        }
    }
}
