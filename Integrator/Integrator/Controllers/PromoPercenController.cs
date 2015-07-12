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
    public class PromoPercenController : Controller
    {
        private IntegratorContext db = new IntegratorContext();

        // GET: /PromoPercen/
        public ActionResult Index()
        {
            return View(db.PromoPercens.ToList());
        }

        // GET: /PromoPercen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoPercen promopercen = db.PromoPercens.Find(id);
            if (promopercen == null)
            {
                return HttpNotFound();
            }
            return View(promopercen);
        }

        // GET: /PromoPercen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PromoPercen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PromoID,nombre,percen")] PromoPercen promopercen)
        {
            if (ModelState.IsValid)
            {
                db.Promos.Add(promopercen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promopercen);
        }

        // GET: /PromoPercen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoPercen promopercen = db.PromoPercens.Find(id);
            if (promopercen == null)
            {
                return HttpNotFound();
            }
            return View(promopercen);
        }

        // POST: /PromoPercen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PromoID,nombre,percen")] PromoPercen promopercen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promopercen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promopercen);
        }

        // GET: /PromoPercen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoPercen promopercen = db.PromoPercens.Find(id);
            if (promopercen == null)
            {
                return HttpNotFound();
            }
            return View(promopercen);
        }

        // POST: /PromoPercen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PromoPercen promopercen = db.PromoPercens.Find(id);
            db.Promos.Remove(promopercen);
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
