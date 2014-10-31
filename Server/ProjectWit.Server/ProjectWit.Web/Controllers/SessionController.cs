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

namespace ProjectWit.Web
{
    public class SessionController : Controller
    {
        private WitDbContext db = new WitDbContext();

        // GET: Session
        public async Task<ActionResult> Index()
        {
            var wit_Session = db.Wit_Session.Include(w => w.Wit_User);
            return View(await wit_Session.ToListAsync());
        }

        // GET: Session/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Session wit_Session = await db.Wit_Session.FindAsync(id);
            if (wit_Session == null)
            {
                return HttpNotFound();
            }
            return View(wit_Session);
        }

        // GET: Session/Create
        public ActionResult Create()
        {
            ViewBag.User_UID = new SelectList(db.Wit_User, "User_UID", "MiddleName");
            return View();
        }

        // POST: Session/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Session_UID,User_UID,Browser,DeviceType,ModifiedDate,ModifiedBy,IP,Location")] Wit_Session wit_Session)
        {
            if (ModelState.IsValid)
            {
                wit_Session.Session_UID = Guid.NewGuid();
                db.Wit_Session.Add(wit_Session);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.User_UID = new SelectList(db.Wit_User, "User_UID", "MiddleName", wit_Session.User_UID);
            return View(wit_Session);
        }

        // GET: Session/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Session wit_Session = await db.Wit_Session.FindAsync(id);
            if (wit_Session == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_UID = new SelectList(db.Wit_User, "User_UID", "MiddleName", wit_Session.User_UID);
            return View(wit_Session);
        }

        // POST: Session/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Session_UID,User_UID,Browser,DeviceType,ModifiedDate,ModifiedBy,IP,Location")] Wit_Session wit_Session)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wit_Session).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.User_UID = new SelectList(db.Wit_User, "User_UID", "MiddleName", wit_Session.User_UID);
            return View(wit_Session);
        }

        // GET: Session/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Session wit_Session = await db.Wit_Session.FindAsync(id);
            if (wit_Session == null)
            {
                return HttpNotFound();
            }
            return View(wit_Session);
        }

        // POST: Session/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Wit_Session wit_Session = await db.Wit_Session.FindAsync(id);
            db.Wit_Session.Remove(wit_Session);
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
