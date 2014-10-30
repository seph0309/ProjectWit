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
            using (WitDbContext db = new WitDbContext(User.Identity.Name))
            {
                var nav = (from col in db.Wit_NavBar
                           select new { Menu = col.Menu, SubMenu = col.SubMenu, URL = col.URL }
                           ).OrderBy(or => or.Menu).ToList();
                return Json(nav, JsonRequestBehavior.AllowGet);
            }
        }
	}
}