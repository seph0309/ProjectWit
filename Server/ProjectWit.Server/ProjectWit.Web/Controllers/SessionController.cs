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
    public class SessionController : WitBaseController
    {
        private IWit_Session ISession;

        public SessionController(IWit_Session iWit)
        {
            ISession = iWit;
        }

        // GET: Session
        public ActionResult Index()
        {
            var wit_Session = ISession.GetSession(Session["userId"].ToString()).ToList();
            
            //If Wit_User is null it means that the user in SYSADMIN/ADMIN role
            if (wit_Session.Count > 0 && wit_Session[0].Wit_User == null)
                ViewBag.ShowFullName = true;
            else
                ViewBag.ShowFullName = false;

            //TODO: Temporarily set it as true
            ViewBag.ShowFullName = true;


            return View(wit_Session);
        }

        // GET: Session/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Session wit_Session = await ISession.FindByIdAsync(id);
            if (wit_Session == null)
            {
                return HttpNotFound();
            }
            return View(wit_Session);
        }

        // GET: Session/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.User_UID = new SelectList(await ISession.GetAllAsync(), "User_UID", "MiddleName");
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
                await ISession.CreateAsync(wit_Session, User.Identity.Name);
                return RedirectToAction("Index");
            }

            ViewBag.User_UID = new SelectList(await ISession.GetAllAsync(), "User_UID", "MiddleName", wit_Session.User_UID);
            return View(wit_Session);
        }

        // GET: Session/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wit_Session wit_Session = await ISession.FindByIdAsync(id);
            if (wit_Session == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_UID = new SelectList(await ISession.GetAllAsync(), "User_UID", "MiddleName", wit_Session.User_UID);
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
                await ISession.UpdateAsync(wit_Session, User.Identity.Name);
                return RedirectToAction("Index");
            }
            ViewBag.User_UID = new SelectList(await ISession.GetAllAsync(), "User_UID", "MiddleName", wit_Session.User_UID);
            return View(wit_Session);
        }

        // GET: Session/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await ISession.RemoveAsync(id);
            return RedirectToAction("Index");
        }
         
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ISession.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
