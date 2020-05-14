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
    public class LoanController : Controller
    {
        private DVDRentalSystemContext db = new DVDRentalSystemContext();

        // GET: Loan
        public ActionResult Index()
        {
            var loans = db.Loans.Include(l => l.DVDDetails).Include(l => l.Member);
            return View(loans.ToList());
        }

        // GET: Loan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: Loan/Create
        public ActionResult Create()
        {
            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "DVDDetailsId", "Name");
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName");
            return View();
        }

        // POST: Loan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoanId,DVDDetailsId,IssueDate,ReturnDate,FineAmount,MemberId")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Loans.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "DVDDetailsId", "Name", loan.DVDDetailsId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", loan.MemberId);
            return View(loan);
        }

        // GET: Loan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "DVDDetailsId", "Name", loan.DVDDetailsId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", loan.MemberId);
            return View(loan);
        }

        // POST: Loan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanId,DVDDetailsId,IssueDate,ReturnDate,FineAmount,MemberId")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DVDDetailsId = new SelectList(db.DVDDetails, "DVDDetailsId", "Name", loan.DVDDetailsId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", loan.MemberId);
            return View(loan);
        }

        // GET: Loan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loan loan = db.Loans.Find(id);
            db.Loans.Remove(loan);
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
