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
    public class CityTblsController : Controller
    {
        private GroceryDBEntities db = new GroceryDBEntities();

        // GET: Admin/CityTbls
        public ActionResult Index()
        {
            var cityTbls = db.CityTbls.Include(c => c.StateTbl);
            return View(cityTbls.ToList());
        }

        // GET: Admin/CityTbls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityTbl cityTbl = db.CityTbls.Find(id);
            if (cityTbl == null)
            {
                return HttpNotFound();
            }
            return View(cityTbl);
        }

        // GET: Admin/CityTbls/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.StateTbls, "Id", "Name");
            return View();
        }

        // POST: Admin/CityTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StateId,IsActive")] CityTbl cityTbl)
        {
            if (ModelState.IsValid)
            {
                db.CityTbls.Add(cityTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.StateTbls, "Id", "Name", cityTbl.StateId);
            return View(cityTbl);
        }

        // GET: Admin/CityTbls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityTbl cityTbl = db.CityTbls.Find(id);
            if (cityTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.StateTbls, "Id", "Name", cityTbl.StateId);
            return View(cityTbl);
        }

        // POST: Admin/CityTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StateId,IsActive")] CityTbl cityTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.StateTbls, "Id", "Name", cityTbl.StateId);
            return View(cityTbl);
        }

        // GET: Admin/CityTbls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityTbl cityTbl = db.CityTbls.Find(id);
            if (cityTbl == null)
            {
                return HttpNotFound();
            }
            return View(cityTbl);
        }

        // POST: Admin/CityTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CityTbl cityTbl = db.CityTbls.Find(id);
            db.CityTbls.Remove(cityTbl);
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
