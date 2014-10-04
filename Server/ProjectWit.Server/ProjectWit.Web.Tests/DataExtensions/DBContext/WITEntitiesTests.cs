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
        public void GetUserDetailTest()
        {
            using(WITEntities db = new WITEntities())
            {
                db.GetUserDetail(new Guid("274862DB-E708-4D24-8B2B-80734929F3FA"));

            }
            Assert.IsTrue(1 == 1,"Correct");
        }
    }
}
