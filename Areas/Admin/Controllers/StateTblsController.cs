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
    public class StateTblsController : Controller
    {
        private GroceryDBEntities db = new GroceryDBEntities();

        // GET: Admin/StateTbls
        public ActionResult Index()
        {
            var stateTbls = db.StateTbls.Include(s => s.CountryTbl);
            return View(stateTbls.ToList());
        }

        // GET: Admin/StateTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateTbl stateTbl = db.StateTbls.Find(id);
            if (stateTbl == null)
            {
                return HttpNotFound();
            }
            return View(stateTbl);
        }

        // GET: Admin/StateTbls/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.CountryTbls, "Id", "Name");
            return View();
        }

        // POST: Admin/StateTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CountryId,IsActive")] StateTbl stateTbl)
        {
            if (ModelState.IsValid)
            {
                db.StateTbls.Add(stateTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.CountryTbls, "Id", "Name", stateTbl.CountryId);
            return View(stateTbl);
        }

        // GET: Admin/StateTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateTbl stateTbl = db.StateTbls.Find(id);
            if (stateTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.CountryTbls, "Id", "Name", stateTbl.CountryId);
            return View(stateTbl);
        }

        // POST: Admin/StateTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CountryId,IsActive")] StateTbl stateTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stateTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.CountryTbls, "Id", "Name", stateTbl.CountryId);
            return View(stateTbl);
        }

        // GET: Admin/StateTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateTbl stateTbl = db.StateTbls.Find(id);
            if (stateTbl == null)
            {
                return HttpNotFound();
            }
            return View(stateTbl);
        }

        // POST: Admin/StateTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StateTbl stateTbl = db.StateTbls.Find(id);
            db.StateTbls.Remove(stateTbl);
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
