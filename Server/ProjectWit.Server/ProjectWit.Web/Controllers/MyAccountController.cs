using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectWit.Model;
using ProjectWit.Web.Models;
using System.Threading.Tasks;

namespace ProjectWit.Web.Controllers
{
    [WitAuthorize]
    public class MyAccountController : WitBaseController
    {
        //
        // GET: /MyAccount/
        public async Task<ActionResult> Index()
        {
            return View();
        }

        public ActionResult GetNavBar()
        {
            using (WitDbContext db = new WitDbContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                return Json(db.GetNavBar(Session["userID"].ToString()), JsonRequestBehavior.AllowGet);
            }
        }
	}
}