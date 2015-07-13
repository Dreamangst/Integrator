using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Integrator.Models;
using Integrator.DAL;
using Integrator.ViewModels;
using Integrator.Models.Promociones;
using Integrator.Models.Estadios;

namespace Integrator.Controllers
{
    public class EventoController : Controller
    {
        private IntegratorContext db = new IntegratorContext();

        // GET: /Evento/
        public ActionResult Index()
        {
            return View(db.Eventos.ToList());
        }

        // GET: /Evento/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: /Evento/Create
        public ActionResult Create()
        {
            var evento = new Evento();
            evento.promociones= new List<Promo>();
            populateBag(evento);
            return View();
        }
        private void populateBag(Evento evnt)
        {
            var allCourses = db.Promos;
            var eventoPromos = new HashSet<int>(evnt.promociones.Select(p => p.PromoID));
            var viewModel = new List<AssignedPromoData>();
            foreach (var prom in allCourses)
            {
                viewModel.Add(new AssignedPromoData
                {
                    PromoID = prom.PromoID,
                    nombre = prom.nombre,
                    assigned = eventoPromos.Contains(prom.PromoID)
                });
            }
            ViewBag.Promos = viewModel;
            Localidades localidades = new Localidades();
            localidades.setStandard();
            ViewBag.Localidades = localidades;
            
        }
        // POST: /Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EventoID,nombre,precioGeneral,calendario")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Eventos.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evento);
        }

        // GET: /Evento/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: /Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EventoID,nombre,precioGeneral,calendario")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: /Evento/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: /Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Evento evento = db.Eventos.Find(id);
            db.Eventos.Remove(evento);
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
