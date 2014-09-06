﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectWit.Model;
using System.Linq;

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

        public ActionResult GetNavBar()
        {
        
            using(WITEntities db = new WITEntities())
            {
                var nav = (from col in db.Wit_NavBar
                           select new { Menu = col.Menu, SubMenu = col.SubMenu, URL = col.URL }).ToList();
                return Json(nav, JsonRequestBehavior.AllowGet);
            }
        }

	}
}