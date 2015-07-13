using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Integrator.Models.Promociones;
using Integrator.Models;
using Integrator.DAL;

namespace Integrator.Controllers
{
    public class PromoNx1Controller : Controller
    {
        private IntegratorContext db = new IntegratorContext();

        // GET: /PromoNx1/
        public ActionResult Index()
        {
            return View(db.PromoNx1s.ToList());
        }

        // GET: /PromoNx1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoNx1 promonx1 = db.PromoNx1s.Find(id);
            if (promonx1 == null)
            {
                return HttpNotFound();
            }
            return View(promonx1);
        }

        // GET: /PromoNx1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PromoNx1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PromoID,nombre,qtty")] PromoNx1 promonx1)
        {
            if (ModelState.IsValid)
            {
                db.Promos.Add(promonx1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promonx1);
        }

        // GET: /PromoNx1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoNx1 promonx1 = db.PromoNx1s.Find(id);
            if (promonx1 == null)
            {
                return HttpNotFound();
            }
            return View(promonx1);
        }

        // POST: /PromoNx1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PromoID,nombre,qtty")] PromoNx1 promonx1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promonx1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promonx1);
        }

        // GET: /PromoNx1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoNx1 promonx1 = db.PromoNx1s.Find(id);
            if (promonx1 == null)
            {
                return HttpNotFound();
            }
            return View(promonx1);
        }

        // POST: /PromoNx1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PromoNx1 promonx1 = db.PromoNx1s.Find(id);
            db.Promos.Remove(promonx1);
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
