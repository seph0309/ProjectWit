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
using ProjectWit.Web.Models;

namespace ProjectWit.Web.Controllers
{
    [WitAuthorize]
    public class CategoryController : WitBaseController
    {
        private IWit_Category ICategory;

        public CategoryController(IWit_Category icat)
        {
            this.ICategory = icat;
        }

        // GET: Category
        public async Task<ActionResult> Index()
        {
            var wit_Category = await ICategory.GetAllAsync();
            return View(wit_Category);
        }

        // GET: Category/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Category wit_Category = await ICategory.FindByIdAsync(id);
            if (wit_Category == null)
            {
                return HttpNotFound();
            }
            return View(wit_Category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            //ViewBag.Company_UID = new SelectList(db.Wit_Company, "Company_UID", "CompanyName");
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Category_UID,Company_UID,CategoryName")] Wit_Category wit_Category)
        {
            if (ModelState.IsValid)
            {
                await ICategory.CreateAsync(wit_Category, User.Identity.Name);
                
                return RedirectToAction("Index");
            }

            //ViewBag.Company_UID = new SelectList(db.Wit_Company, "Company_UID", "CompanyName", wit_Category.Company_UID);
            return View(wit_Category);
        }

        // GET: Category/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Category wit_Category = await ICategory.FindByIdAsync(id);
            if (wit_Category == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Company_UID = new SelectList(db.Wit_Company, "Company_UID", "CompanyName", wit_Category.Company_UID);
            return View(wit_Category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Category_UID,Company_UID,CategoryName")] Wit_Category wit_Category)
        {
            if (ModelState.IsValid)
            {
                await ICategory.UpdateAsync(wit_Category, User.Identity.Name);
                return RedirectToAction("Index");
            }
            //ViewBag.Company_UID = new SelectList(db.Wit_Company, "Company_UID", "CompanyName", wit_Category.Company_UID);
            return View(wit_Category);
        }

        // GET: Category/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Category wit_Category = await ICategory.FindByIdAsync(id);
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
            await ICategory.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ICategory.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
