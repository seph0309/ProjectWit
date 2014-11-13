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

        private IWit_NavBar INavBar;

        public MyAccountController(IWit_NavBar inavBar)
        {
            INavBar = inavBar;
        }
        //
        // GET: /MyAccount/
        public async Task<ActionResult> Index()
        {
            return View();
        }

        public ActionResult GetNavBar()
        {
            return Json(INavBar.GetNavBar(Session["userID"].ToString()), JsonRequestBehavior.AllowGet); ;
        }
	}
}