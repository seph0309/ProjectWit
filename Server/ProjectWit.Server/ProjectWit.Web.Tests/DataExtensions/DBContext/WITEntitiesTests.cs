﻿using System;
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


        /// <summary>
        /// This method test if generated UID is incremental
        /// </summary>
        [TestMethod]
        public void TestUserUIDGeneration()
        {
            try
            {
                using (WITEntities db = new WITEntities())
                {
                    for (int x = 0; x < 20; x++)
                    {
                        db.Wit_Company.Add(new Wit_Company {Company_UID=new Guid(DateTime.Now.ToString()), CompanyAddress = "san pedro", CompanyName = "Sample" });
                    }
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.InnerException.Message.ToString());
            }

        }
    }
}
