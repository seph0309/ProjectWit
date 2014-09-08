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
    [Authorize]
    public class CategoryController : Controller
    {
        private WITEntities db = new WITEntities();

        // GET: Category
        public async Task<ActionResult> Index()
        {
            var wit_Category = db.Wit_Category.Include(w => w.Wit_Company);
            return View(await wit_Category.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Category wit_Category = await db.Wit_Category.FindAsync(id);
            if (wit_Category == null)
            {
                return HttpNotFound();
            }
            return View(wit_Category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            ViewBag.Company_UID = new SelectList(db.Wit_Company, "Company_UID", "CompanyName");
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Category_UID,Company_UID,CategoryName,ModifiedDate,ModifiedBy")] Wit_Category wit_Category)
        {
            if (ModelState.IsValid)
            {
                wit_Category.Category_UID = Guid.NewGuid();
                db.Wit_Category.Add(wit_Category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Company_UID = new SelectList(db.Wit_Company, "Company_UID", "CompanyName", wit_Category.Company_UID);
            return View(wit_Category);
        }

        // GET: Category/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Category wit_Category = await db.Wit_Category.FindAsync(id);
            if (wit_Category == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company_UID = new SelectList(db.Wit_Company, "Company_UID", "CompanyName", wit_Category.Company_UID);
            return View(wit_Category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Category_UID,Company_UID,CategoryName,ModifiedDate,ModifiedBy")] Wit_Category wit_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wit_Category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Company_UID = new SelectList(db.Wit_Company, "Company_UID", "CompanyName", wit_Category.Company_UID);
            return View(wit_Category);
        }

        // GET: Category/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Category wit_Category = await db.Wit_Category.FindAsync(id);
            if (wit_Category == null)
            {
                return HttpNotFound();
            }
            return View(wit_Category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Wit_Category wit_Category = await db.Wit_Category.FindAsync(id);
            db.Wit_Category.Remove(wit_Category);
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
