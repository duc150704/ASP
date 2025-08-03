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
    public class PhimsController : Controller
    {
        private PhimDB db = new PhimDB();

        // GET: Phims
        public ActionResult Index()
        {
            var phim = db.Phim.Include(p => p.LoaiPhim);
            return View(phim.ToList());
        }

        // GET: Phims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phim.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // GET: Phims/Create
        public ActionResult Create()
        {
            ViewBag.ID_LoaiPhim = new SelectList(db.LoaiPhim, "ID_LoaiPhim", "TenLoai");
            return View();
        }

        // POST: Phims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Phim,Ten_Phim,Dao_Dien,Anh,Ngay_Khoi_Chieu,ID_LoaiPhim")] Phim phim)
        {
            if (ModelState.IsValid)
            {
                db.Phim.Add(phim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LoaiPhim = new SelectList(db.LoaiPhim, "ID_LoaiPhim", "TenLoai", phim.ID_LoaiPhim);
            return View(phim);
        }

        // GET: Phims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phim.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LoaiPhim = new SelectList(db.LoaiPhim, "ID_LoaiPhim", "TenLoai", phim.ID_LoaiPhim);
            return View(phim);
        }

        // POST: Phims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Phim,Ten_Phim,Dao_Dien,Anh,Ngay_Khoi_Chieu,ID_LoaiPhim")] Phim phim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LoaiPhim = new SelectList(db.LoaiPhim, "ID_LoaiPhim", "TenLoai", phim.ID_LoaiPhim);
            return View(phim);
        }

        // GET: Phims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phim.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // POST: Phims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phim phim = db.Phim.Find(id);
            db.Phim.Remove(phim);
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
