using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NewApp.Models;

namespace NewApp.Controllers
{
    public class AccountController : Controller
    {
        private TestBankEntities db = new TestBankEntities();

        // GET: Account
        public ActionResult Index()
        {
            return View(db.Bank_Account.ToList());
        }

        // GET: Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Account bank_Account = db.Bank_Account.Find(id);
            if (bank_Account == null)
            {
                return HttpNotFound();
            }
            return View(bank_Account);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccNo,AssetId,OpenDate,CloseDate")] Bank_Account bank_Account)
        {
            if (ModelState.IsValid)
            {
                db.Bank_Account.Add(bank_Account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bank_Account);
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Account bank_Account = db.Bank_Account.Find(id);
            if (bank_Account == null)
            {
                return HttpNotFound();
            }
            return View(bank_Account);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccNo,AssetId,OpenDate,CloseDate")] Bank_Account bank_Account)
        {
            if (ModelState.IsValid)
            {
                //创建instance
                db.Entry(bank_Account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bank_Account);
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank_Account bank_Account = db.Bank_Account.Find(id);
            if (bank_Account == null)
            {
                return HttpNotFound();
            }
            return View(bank_Account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bank_Account bank_Account = db.Bank_Account.Find(id);
            db.Bank_Account.Remove(bank_Account);
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
        //生成log file，并下载
        public ActionResult GetLog()
        {
            int Counter = 1;
            string Filedone = "The log Final Status Showing whether the data can pass the validation rules or not!" + "\n" + "\n" + "\n";
            //使用store procedures处理log 信息
            var ResultLog = db.SpGetLog().ToList();

            foreach (var log in ResultLog)
            {
                Filedone += Counter + ":    " + "AccNo: " + log.AccNo + ", RelatedId: " + log.RelatedId + ", FinalStatus: " + log.FinalStatus + "\n";
                Counter++;
            }
            var byteArray = Encoding.ASCII.GetBytes(Filedone);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", "LogFile.txt");
        }

    }
}
