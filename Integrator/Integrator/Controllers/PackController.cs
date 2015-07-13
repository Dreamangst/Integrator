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
    public class PackController : Controller
    {
        private IntegratorContext db = new IntegratorContext();

        // GET: /Pack/
        public ActionResult Index()
        {
            return View(db.Packs.ToList());
        }

        // GET: /Pack/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pack pack = db.Packs.Find(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // GET: /Pack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Pack/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="packID,nombre,detalles,stock")] Pack pack)
        {
            if (ModelState.IsValid)
            {
                db.Packs.Add(pack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pack);
        }

        // GET: /Pack/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pack pack = db.Packs.Find(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: /Pack/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="packID,nombre,detalles,stock")] Pack pack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pack);
        }

        // GET: /Pack/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pack pack = db.Packs.Find(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: /Pack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Pack pack = db.Packs.Find(id);
            db.Packs.Remove(pack);
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
