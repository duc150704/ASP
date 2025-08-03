using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EF.Models;

namespace EF.Controllers
{
    public class LoaiPhimsController : Controller
    {
        private PhimDB db = new PhimDB();

        // GET: LoaiPhims
        public ActionResult Index()
        {
            return View(db.LoaiPhim.ToList());
        }

        // GET: LoaiPhims/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhim loaiPhim = db.LoaiPhim.Find(id);
            if (loaiPhim == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhim);
        }

        // GET: LoaiPhims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiPhims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_LoaiPhim,TenLoai")] LoaiPhim loaiPhim)
        {
            if (ModelState.IsValid)
            {
                db.LoaiPhim.Add(loaiPhim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiPhim);
        }

        // GET: LoaiPhims/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhim loaiPhim = db.LoaiPhim.Find(id);
            if (loaiPhim == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhim);
        }

        // POST: LoaiPhims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_LoaiPhim,TenLoai")] LoaiPhim loaiPhim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiPhim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiPhim);
        }

        // GET: LoaiPhims/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhim loaiPhim = db.LoaiPhim.Find(id);
            if (loaiPhim == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhim);
        }

        // POST: LoaiPhims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiPhim loaiPhim = db.LoaiPhim.Find(id);
            db.LoaiPhim.Remove(loaiPhim);
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
