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

namespace ProjectWit.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private WITEntities db = new WITEntities();
        private ApplicationDbContext Userdb = new ApplicationDbContext();

        // GET: User
        public async Task<ActionResult> Index()
        {
            return View(await db.UsersViewModels.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersViewModel usersViewModel = await db.UsersViewModels.FindAsync(id);
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
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersViewModel usersViewModel = db.UsersViewModels.Find(id);
            
            if (usersViewModel == null)
            {
                return HttpNotFound();
            }
            usersViewModel.AspNetRole = ((List<AspNetRole>)Userdb.GetRoles(usersViewModel.User_UID.ToString()));

            ViewBag.Company_UID = new SelectList(db.Wit_Company, "Company_UID", "CompanyName", usersViewModel.Company_UID);
            ViewBag.IsSysAdmin = usersViewModel.IsSysAdmin;

            if (Convert.ToString(Session["UserID"]) == id.ToString())
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
        public ActionResult Edit([Bind(Include = "User_UID,FirstName,MiddleName,LastName,Company_UID,EmailAddress,Id,Name,IsSelected")] UsersViewModel usersViewModel, List<AspNetRole> aspnetRole)
        {
            if (ModelState.IsValid)
            {
                db.UpdateUser(usersViewModel);
                Userdb.UpdateRole(usersViewModel.User_UID.ToString(), aspnetRole);

                if (Convert.ToString(Session["UserID"]) == usersViewModel.User_UID.ToString().ToUpper())
                    return RedirectToAction("Index","MyAccount",null);
                else
                    return RedirectToAction("Index");
            }
            usersViewModel.AspNetRole = Userdb.GetRoles(usersViewModel.User_UID.ToString());
            ViewBag.Company_UID = new SelectList(db.Wit_Company, "Company_UID", "CompanyName", usersViewModel.Company_UID);
            return View(usersViewModel);
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            db.DeleteUser(id);
            return RedirectToAction("Index");
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            UsersViewModel usersViewModel = await db.UsersViewModels.FindAsync(id);
            db.UsersViewModels.Remove(usersViewModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
