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
    public class MyAccountController : Controller
    {
        //
        // GET: /MyAccount/
        public async Task<ActionResult> Index()
        {
            if (Session["UserID"] == null)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var user = await db.UserManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                    Session["UserID"] = user.Id;
            }
            return View();
        }

        public ActionResult GetNavBar()
        {
            using (WITEntities db = new WITEntities(User.Identity.Name))
            {
                var nav = (from col in db.Wit_NavBar
                           select new { Menu = col.Menu, SubMenu = col.SubMenu, URL = col.URL }
                           ).OrderBy(or => or.SubMenu).ToList();
                return Json(nav, JsonRequestBehavior.AllowGet);
            }
        }
	}
}