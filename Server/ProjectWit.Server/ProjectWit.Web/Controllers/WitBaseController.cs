using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectWit.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectWit.Web.Models;
using System.Collections;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace ProjectWit.Web.Controllers
{
    public abstract class WitBaseController : Controller, ISessionManager<ApplicationUser>
    {
        //All common methods goes here
        ApplicationDbContext Userdb = new ApplicationDbContext();
        
        public void SetSessions(ApplicationUser user)
        {
            Session["userID"] = User.Identity.GetUserId(); 
            Session["IsSysAdmin"] = User.IsInRole(AspNetRole.SYSADMIN);
        }

        public void ReloadCurrentSession(string userID)
        {
            var user = Userdb.UserManager.FindById(userID);
            Userdb.UpdateUserLogin(HttpContext.GetOwinContext().Authentication, user);
            //SetSessions(user);
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Session["userID"] == null)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var user = db.UserManager.FindByName(User.Identity.Name);
                    if (user != null)
                    {
                        SetSessions(user);
                    }
                }
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Userdb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}