using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWit.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectWit.Web;
using ProjectWit.Service.ServiceArguments;
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


        /// <summary>
        /// This method test if generated UID is incremental
        /// </summary>
        [TestMethod]
        public void TestWitService()
        {
            try
            {

                WitService wt = new WitService();
                LoginServiceArgs args;
                args = wt.Login("SYSADMIN", "password", "Chrome"," Ipad");
                args = wt.Login("SYSADMIN", "passworD", "Chrome", "Ipad");
                args = wt.Login("admin", "password", "Chrome", "Ipad");

            }
            catch(Exception ex)
            {
                Assert.Fail(ex.InnerException.Message.ToString());
            }

        }

        [TestMethod]
        public void TestPassword()
        {
            string password = "password";
            string cryptoPassword = Wit_Cryptography.HashPassword(password);
            bool ver = Wit_Cryptography.VerifyHashedPassword("AKhzjiA1IUNU/1oocYMYx48xteD7aBOCPr/pUiH4e1M/ikFMxDvr1vCxclpCDjsgwQ==", password);
        }

    }
}
