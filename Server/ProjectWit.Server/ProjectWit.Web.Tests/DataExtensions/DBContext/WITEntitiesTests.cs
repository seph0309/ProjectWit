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

        [TestMethod]
        public void TestWitStatus()
        {
            string x = Wit_Status.Open.ToString();

            List<KeyValuePair<int, string>> Status = Wit_Status.Status;
            string value = Status[0].Value;

            using (WitDbContext db = new WitDbContext())
            {

                string _sql = string.Empty;
                _sql = "SELECT Menu,SubMenu,URL FROM Wit_NavBar WHERE Menu= '{0}'";

                string var = string.Format(_sql, "hello");

                List<Wit_NavBar> bar = new List<Wit_NavBar>();
                var _bar = db.GetNavBar("299A2AD2-B6A4-47E8-A66A-CA84333AF7C0");
                
            }
        }

        [TestMethod]
        public async Task GetSessionTest()
        {
            string SYSADMIN = "299A2AD2-B6A4-47E8-A66A-CA84333AF7C0";
            string ADMIN = "299A2AD2-B6A4-47E8-A66A-CA84333AF7C2";
            string CREW = "299A2AD2-B6A4-47E8-A66A-CA84333AF7C1";
            string CUSTOMER = "31CAA23C-A8CE-4F25-B737-C435AD71A443";
            string GUEST = "299A2AD2-B6A4-47E8-A66A-CA84333AF7C3";
            Guid SampleSession = new Guid("63340BA6-2F61-E411-8182-0021CCC18CF4");

            Wit_Session db = new Wit_Session();
            //TODO: Test the results. They must match with the roles they are in
            var joseph = await db.GetByIdAsync(SampleSession);
             
            Wit_Session wit = new Wit_Session { User_UID = new Guid(SYSADMIN) };
            await db.CreateAsync(wit, "sephTest");

            db.RemoveAsync(wit.Session_UID);


            var ret = db.GetSession(SYSADMIN);
            var ret2 = db.GetSession(ADMIN);
            var ret3 = db.GetSession(CREW);
            //ret = db.GetSession(CUSTOMER);
            ret = db.GetSession(GUEST);
        }
    }
}
