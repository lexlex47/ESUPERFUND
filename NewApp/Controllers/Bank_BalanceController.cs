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
    public class Bank_BalanceController : Controller
    {
        private TestBankEntities db = new TestBankEntities();

        // GET: Bank_Balance
        public ActionResult Index()
        {
            return View(db.Bank_Balance.ToList());
        }

        // GET: Bank_Balance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Balance bank_Balance = db.Bank_Balance.Find(id);
            if (bank_Balance == null)
            {
                return HttpNotFound();
            }
            return View(bank_Balance);
        }

        // GET: Bank_Balance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bank_Balance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AssetId,BalanceDate,Balance")] Bank_Balance bank_Balance)
        {
            if (ModelState.IsValid)
            {
                db.Bank_Balance.Add(bank_Balance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bank_Balance);
        }

        // GET: Bank_Balance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Balance bank_Balance = db.Bank_Balance.Find(id);
            if (bank_Balance == null)
            {
                return HttpNotFound();
            }
            return View(bank_Balance);
        }

        // POST: Bank_Balance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssetId,BalanceDate,Balance")] Bank_Balance bank_Balance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bank_Balance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bank_Balance);
        }

        // GET: Bank_Balance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Balance bank_Balance = db.Bank_Balance.Find(id);
            if (bank_Balance == null)
            {
                return HttpNotFound();
            }
            return View(bank_Balance);
        }

        // POST: Bank_Balance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bank_Balance bank_Balance = db.Bank_Balance.Find(id);
            db.Bank_Balance.Remove(bank_Balance);
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
