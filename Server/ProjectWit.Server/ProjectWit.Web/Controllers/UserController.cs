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

namespace ProjectWit.Web.Controllers
{
    public class UserController : Controller
    {
        private WITEntities db = new WITEntities();

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
            return View();
        }

        //// POST: User/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "User_UID,FirstName,MiddleName,LastName,Company_UID,EmailAddress,ModifiedDate,ModifiedBy,UserName,CompanyName,CompanyAddress,CompanyNumber")] UsersViewModel usersViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        usersViewModel.User_UID = Guid.NewGuid();
        //        db.UsersViewModels.Add(usersViewModel);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(usersViewModel);
        //}

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
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

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "User_UID,FirstName,MiddleName,LastName,Company_UID,EmailAddress,ModifiedDate,ModifiedBy,UserName,CompanyName,CompanyAddress,CompanyNumber")] UsersViewModel usersViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usersViewModel);
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
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
