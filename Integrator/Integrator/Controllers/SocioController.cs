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
using System.Data.Entity.Infrastructure;

namespace Integrator.Controllers
{
    public class SocioController : Controller
    {
        private IntegratorContext db = new IntegratorContext();

        // GET: /Socio/
        public ActionResult Index(int? id, int? promoID)
        {
            var viewModel = new SociosIndexData();

            

            viewModel.Socios = db.Socios
                /*
                .Include(i => i.SocioID)
                .Include(i => i.nombre)
                .Include(i => i.ci)
                .Include(i => i.promociones.Select(c => c.PromoID))
                .Include(i => i.promociones.Select(c => c.nombre))
                */
                
                .OrderBy(i => i.nombre);

            if (id != null)
            {
                ViewBag.SocioID = id.Value;
                viewModel.Promociones = viewModel.Socios.Where(
                    i => i.SocioID == id.Value).Single().promociones;
            }
            /*if (promoID != null)
            {
                ViewBag.PromoID = promoID.Value;
                var selectedPromo = viewModel.Promociones.Where(x => x.PromoID == promoID).Single();
                //db.Entry(selectedPromo).Collection(x => x.PromoID).Load();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    db.Entry(enrollment).Reference(x => x.Student).Load();
                }

                viewModel.Enrollments = selectedCourse.Enrollments;
            }*/
            return View(viewModel);
            /*
            if (promoID != null)
            {
                ViewBag.PromoID = promoID.Value;
                // Lazy loading
                //viewModel.Enrollments = viewModel.Courses.Where(
                //    x => x.CourseID == courseID).Single().Enrollments;
                // Explicit loading
                var selectedPromo = viewModel.Promociones.Where(x => x.PromoID == promoID).Single();
                db.Entry(selectedPromo).Collection(x => x.PromoID).Load();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    db.Entry(enrollment).Reference(x => x.Student).Load();
                }

                viewModel.Enrollments = selectedCourse.Enrollments;
            }*/

            

            //return View(db.Socios.ToList());
        }

        // GET: /Socio/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // GET: /Socio/Create
        public ActionResult Create()
        {
            var socio = new Socio();
            socio.promociones = new List<Promo>();
            populateAssignedPromos(socio);
            return View();
        }
        private void populateAssignedPromos(Socio pSocio)
        {
            var allPromos = db.Promos;
            var socioPromos = new HashSet<int>(pSocio.promociones.Select(c => c.PromoID));
            var viewModel = new List<AssignedPromoData>();
            foreach (var prom in allPromos)
            {
                viewModel.Add(new AssignedPromoData
                {
                    PromoID = prom.PromoID,
                    nombre = prom.nombre,
                    assigned = socioPromos.Contains(prom.PromoID)
                });
            }
            ViewBag.Promos = viewModel;
        }

        // POST: /Socio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocioID,nombre,ci")] Socio socio, string[] selectedPromos)
        {
            if (selectedPromos != null)
            {
                socio.promociones = new List<Promo>();
                foreach (var prom in selectedPromos)
                {
                    var promToAdd = db.Promos.Find(int.Parse(prom));
                    socio.promociones.Add(promToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                db.Socios.Add(socio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            populateAssignedPromos(socio);
            return View(socio);
        }

        // GET: /Socio/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio soc = db.Socios
                /*
                .Include(i => i.nombre)
                .Include(i => i.ci)
                .Include(i => i.SocioID)
                */
                .Where(i => i.SocioID == id)
                .Single();

            populateAssignedPromos(soc);

            if (soc == null)
            {
                return HttpNotFound();
            }
            return View(soc);
        }

        // POST: /Socio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SocioID,nombre, ci")] Socio socio, int? id, string[] selectedPromos)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var socioToUpdate = db.Socios
                /*
               .Include(i => i.ci)
               .Include(i => i.nombre)
               .Include(i => i.promociones)
                */
               .Where(i => i.SocioID == id)
               .Single();

            if (TryUpdateModel(socioToUpdate, "",
               new string[] { "ci", "nombre"}))
            {
                try
                {
                    /*
                    if (String.IsNullOrWhiteSpace(socioToUpdate.OfficeAssignment.Location))
                    {
                        instructorToUpdate.OfficeAssignment = null;
                    }*/

                    updateSocioPromos(selectedPromos, socioToUpdate);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            populateAssignedPromos(socioToUpdate);
            return View(socioToUpdate);
        }
        private void updateSocioPromos(string[] selectedPromos, Socio socioToUpdate)
        {
            if (selectedPromos == null)
            {
                socioToUpdate.promociones = new List<Promo>();
                return; // puaj
            }

            var selectedPromosHS = new HashSet<string>(selectedPromos);
            var socioPromos= new HashSet<int>
                (socioToUpdate.promociones.Select(c => c.PromoID));
            foreach (var prom in db.Promos) //performance? disculpa, no conozco ese plato (?)
            {
                if (selectedPromosHS.Contains(prom.PromoID.ToString()))
                {
                    if (!socioPromos.Contains(prom.PromoID))
                    {
                        socioToUpdate.promociones.Add(prom);
                    }
                }
                else
                {
                    if (socioPromos.Contains(prom.PromoID))
                    {
                        socioToUpdate.promociones.Remove(prom);
                    }
                }
            }
        }
        // GET: /Socio/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: /Socio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Socio socio = db.Socios.Find(id);
            db.Socios.Remove(socio);
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
