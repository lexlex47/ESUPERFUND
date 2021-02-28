using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewApp.Models;

namespace NewApp.Controllers
{
    public class Raw_Bank_BalanceController : Controller
    {
        private TestBankEntities db = new TestBankEntities();

        // GET: Raw_Bank_Balance
        public ActionResult Index()
        {
            return View(db.Raw_Bank_Balance.ToList());
        }

        // GET: Raw_Bank_Balance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Bank_Balance raw_Bank_Balance = db.Raw_Bank_Balance.Find(id);
            if (raw_Bank_Balance == null)
            {
                return HttpNotFound();
            }
            return View(raw_Bank_Balance);
        }

        // GET: Raw_Bank_Balance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raw_Bank_Balance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FinalStatus,RelatedId,AccNo,BalanceDate,Balance")] Raw_Bank_Balance raw_Bank_Balance)
        {
            if (ModelState.IsValid)
            {
                db.Raw_Bank_Balance.Add(raw_Bank_Balance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raw_Bank_Balance);
        }

        // GET: Raw_Bank_Balance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Bank_Balance raw_Bank_Balance = db.Raw_Bank_Balance.Find(id);
            if (raw_Bank_Balance == null)
            {
                return HttpNotFound();
            }
            return View(raw_Bank_Balance);
        }

        // POST: Raw_Bank_Balance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FinalStatus,RelatedId,AccNo,BalanceDate,Balance")] Raw_Bank_Balance raw_Bank_Balance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raw_Bank_Balance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raw_Bank_Balance);
        }

        // GET: Raw_Bank_Balance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Bank_Balance raw_Bank_Balance = db.Raw_Bank_Balance.Find(id);
            if (raw_Bank_Balance == null)
            {
                return HttpNotFound();
            }
            return View(raw_Bank_Balance);
        }

        // POST: Raw_Bank_Balance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raw_Bank_Balance raw_Bank_Balance = db.Raw_Bank_Balance.Find(id);
            db.Raw_Bank_Balance.Remove(raw_Bank_Balance);
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
