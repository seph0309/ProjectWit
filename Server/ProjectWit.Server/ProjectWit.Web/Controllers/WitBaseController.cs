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
    public abstract class WitBaseController : Controller, ISessionManagement
    {
        //All common methods goes here
        ApplicationDbContext Userdb = new ApplicationDbContext();

        /// <summary>
        /// Updates the session key values
        /// </summary>
        /// <param name="user"></param>
        public void SetSessions(ApplicationUser user)
        {
            Session["userID"] = user.Id;
            Session["IsSysAdmin"] = user.IsSysAdmin;
        }

        /// <summary>
        /// Reloads the current session key values
        /// </summary>
        /// <param name="userID"></param>
        public void ReloadCurrentSession(string userID)
        {
            var user = Userdb.UserManager.FindById(userID);
            Userdb.UpdateUserLogin(HttpContext.GetOwinContext().Authentication, user);
            SetSessions(user);
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