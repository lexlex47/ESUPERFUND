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
    public class Bank_TransactionController : Controller
    {
        private TestBankEntities db = new TestBankEntities();

        // GET: Bank_Transaction
        public ActionResult Index()
        {
            return View(db.Bank_Transaction.ToList());
        }

        // GET: Bank_Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Transaction bank_Transaction = db.Bank_Transaction.Find(id);
            if (bank_Transaction == null)
            {
                return HttpNotFound();
            }
            return View(bank_Transaction);
        }

        // GET: Bank_Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bank_Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AssetId,TransactionDate,Amount,RunningBalance")] Bank_Transaction bank_Transaction)
        {
            if (ModelState.IsValid)
            {
                db.Bank_Transaction.Add(bank_Transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bank_Transaction);
        }

        // GET: Bank_Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Transaction bank_Transaction = db.Bank_Transaction.Find(id);
            if (bank_Transaction == null)
            {
                return HttpNotFound();
            }
            return View(bank_Transaction);
        }

        // POST: Bank_Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssetId,TransactionDate,Amount,RunningBalance")] Bank_Transaction bank_Transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bank_Transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bank_Transaction);
        }

        // GET: Bank_Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Transaction bank_Transaction = db.Bank_Transaction.Find(id);
            if (bank_Transaction == null)
            {
                return HttpNotFound();
            }
            return View(bank_Transaction);
        }

        // POST: Bank_Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bank_Transaction bank_Transaction = db.Bank_Transaction.Find(id);
            db.Bank_Transaction.Remove(bank_Transaction);
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
