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
    public class CompanyController : WitBaseController
    {
        private IWit_Company ICompany;

        public CompanyController(IWit_Company iComp)
        {
            ICompany = iComp;
        }

        // GET: Company
        public async Task<ActionResult> Index()
        {
            return View(await ICompany.GetAllAsync());
        }

        // GET: Company/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Company wit_Company = await ICompany.FindByIdAsync(id);
            if (wit_Company == null)
            {
                return HttpNotFound();
            }
            return View(wit_Company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Company_UID,CompanyName,CompanyAddress,CompanyNumber,ModifiedDate,ModifiedBy")] Wit_Company wit_Company)
        {
            if (ModelState.IsValid)
            {
                await ICompany.CreateAsync(wit_Company, User.Identity.Name);
                return RedirectToAction("Index");
            }

            return View(wit_Company);
        }

        // GET: Company/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Company wit_Company = await ICompany.FindByIdAsync(id);
            if (wit_Company == null)
            {
                return HttpNotFound();
            }
            return View(wit_Company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Company_UID,CompanyName,CompanyAddress,CompanyNumber,ModifiedDate,ModifiedBy")] Wit_Company wit_Company)
        {
            if (ModelState.IsValid)
            {
                ICompany.UpdateAsync(wit_Company, User.Identity.Name);
                return RedirectToAction("Index");
            }
            return View(wit_Company);
        }

        // GET: Company/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await ICompany.RemoveAsync(id);
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ICompany.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
