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
    [WitAuthorize]
    public class UserController : WitBaseController
    {
        private IWit_User IUser;
        private IWit_Company ICompany;
        private IUsersViewModel IUserView;

        public UserController(IWit_User iUser, IWit_Company iComp, IUsersViewModel iUserView) 
        {
            IUser = iUser;
            ICompany = iComp;
            IUserView = iUserView;
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            return View(await IUserView.GetAllAsync());
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersViewModel usersViewModel = await IUserView.FindByIdAsync(id);
            if (usersViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usersViewModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return Redirect("/Account/Register");
        }

        // GET: User/Edit/0416
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                id = new Guid(Session["UserID"].ToString());
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersViewModel usersViewModel =  IUserView.GetUserDetail(id);
            
            if (usersViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.Company_UID = new SelectList(await ICompany.GetAllAsync(), "Company_UID", "CompanyName", usersViewModel.Company_UID);
            ViewBag.IsSysAdmin = User.IsInRole(AspNetRole.SYSADMIN);

            if (User.Identity.GetUserId() == id.ToString())
                ViewBag.Title = "User Profile";
            else
                ViewBag.Title = "Edit My Profile";

            return View(usersViewModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "User_UID,FirstName,MiddleName,LastName,Company_UID,EmailAddress,Id,Name,IsSelected")] UsersViewModel usersViewModel, List<AspNetRole> aspnetRole)
        {
            if (ModelState.IsValid)
            {
                usersViewModel.AspNetRole = aspnetRole;
                IUserView.UpdateUser(usersViewModel, User.Identity.Name);

                if (Convert.ToString(Session["UserID"]) == usersViewModel.User_UID.ToString().ToUpper())
                {
                    ReloadCurrentSession(usersViewModel.User_UID.ToString());
                    return RedirectToAction("Index", "MyAccount", null);
                }
                else
                    return RedirectToAction("Index");
            }
            ViewBag.Company_UID = new SelectList(await ICompany.GetAllAsync(), "Company_UID", "CompanyName", usersViewModel.Company_UID);
            return View(usersViewModel);
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            await IUser.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await IUserView.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                IUser.Dispose();
                IUserView.Dispose();
                ICompany.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
