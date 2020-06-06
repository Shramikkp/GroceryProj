using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroceryPR.Models;

namespace GroceryPR.Areas.Admin.Controllers
{
    public class CountryTblsController : Controller
    {
        private GroceryDBEntities db = new GroceryDBEntities();

        // GET: Admin/CountryTbls
        public ActionResult Index()
        {
            return View(db.CountryTbls.ToList());
        }

        // GET: Admin/CountryTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryTbl countryTbl = db.CountryTbls.Find(id);
            if (countryTbl == null)
            {
                return HttpNotFound();
            }
            return View(countryTbl);
        }

        // GET: Admin/CountryTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CountryTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsActive")] CountryTbl countryTbl)
        {
            if (ModelState.IsValid)
            {
                db.CountryTbls.Add(countryTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countryTbl);
        }

        // GET: Admin/CountryTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryTbl countryTbl = db.CountryTbls.Find(id);
            if (countryTbl == null)
            {
                return HttpNotFound();
            }
            return View(countryTbl);
        }

        // POST: Admin/CountryTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsActive")] CountryTbl countryTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryTbl);
        }

        // GET: Admin/CountryTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryTbl countryTbl = db.CountryTbls.Find(id);
            if (countryTbl == null)
            {
                return HttpNotFound();
            }
            return View(countryTbl);
        }

        // POST: Admin/CountryTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryTbl countryTbl = db.CountryTbls.Find(id);
            db.CountryTbls.Remove(countryTbl);
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
