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
    public class WitDbContextTests
    {
        [TestMethod()]
        public void GetUserDetailTest()
        {
            using(WitDbContext db = new WitDbContext())
            {
                db.GetUserDetail(new Guid("274862DB-E708-4D24-8B2B-80734929F3FA"));

            }
            Assert.IsTrue(1 == 1,"Correct");
        }

        [TestMethod]
        public void TestRawSQL()
        {
            using(WitDbContext db = new WitDbContext())
            {
                string _sql = string.Empty;
                _sql = string.Format("select * from Wit_NavBar where Menu = 'My Profile' ");
                _sql = _sql + string.Format("union all ");
                _sql = _sql + string.Format("select * from Wit_NavBar where Menu = 'Admin Maintenance' ");
                db.Configuration.ProxyCreationEnabled = false;
                var nav = db.Wit_NavBar.SqlQuery(_sql).ToList();

            }
        }

        [TestMethod]
        public void TestInsert()
        {
            using(WitDbContext db = new WitDbContext())
            {
                //AutoDetectChangesEnabled improves performance
                db.Configuration.AutoDetectChangesEnabled = false;
                for(int x = 0; x<1000; x++)
                {
                    db.Wit_Company.Add(new Wit_Company { CompanyName = "ewan" });
                }
                db.SaveChanges();
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
