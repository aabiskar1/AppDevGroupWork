using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DVDRentalSystem.Models;
using DataContext.Data;

namespace DVDRentalSystem.Controllers
{
    public class DVDMembersController : Controller
    {
        private DVDRentalSystemContext db = new DVDRentalSystemContext();

        // GET: DVDMembers
        public ActionResult Index()
        {
            var dVDMembers = db.DVDMembers.Include(d => d.DVDDetails).Include(d => d.Members);
            return View(dVDMembers.ToList());
        }

        // GET: DVDMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDMember dVDMember = db.DVDMembers.Find(id);
            if (dVDMember == null)
            {
                return HttpNotFound();
            }
            return View(dVDMember);
        }

        // GET: DVDMembers/Create
        public ActionResult Create()
        {
            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "DVDDetailsId", "Name");
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName");
            return View();
        }

        // POST: DVDMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DVDMemberId,MemberId,DVDDetailsId")] DVDMember dVDMember)
        {
            if (ModelState.IsValid)
            {
                db.DVDMembers.Add(dVDMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "DVDDetailsId", "Name", dVDMember.DVDDetailsId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", dVDMember.MemberId);
            return View(dVDMember);
        }

        // GET: DVDMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDMember dVDMember = db.DVDMembers.Find(id);
            if (dVDMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "DVDDetailsId", "Name", dVDMember.DVDDetailsId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", dVDMember.MemberId);
            return View(dVDMember);
        }

        // POST: DVDMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DVDMemberId,MemberId,DVDDetailsId")] DVDMember dVDMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVDMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "DVDDetailsId", "Name", dVDMember.DVDDetailsId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", dVDMember.MemberId);
            return View(dVDMember);
        }

        // GET: DVDMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDMember dVDMember = db.DVDMembers.Find(id);
            if (dVDMember == null)
            {
                return HttpNotFound();
            }
            return View(dVDMember);
        }

        // POST: DVDMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DVDMember dVDMember = db.DVDMembers.Find(id);
            db.DVDMembers.Remove(dVDMember);
            db.SaveChanges();
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
