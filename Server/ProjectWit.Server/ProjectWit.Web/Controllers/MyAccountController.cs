using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWit.Web.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
        //
        // GET: /MyAccount/
        public ActionResult Index()
        {
            return View();
        }

	}
}