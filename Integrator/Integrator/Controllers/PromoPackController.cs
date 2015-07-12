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
using Integrator.ViewModels;
using System.Threading.Tasks;
using Integrator.DAL;

namespace Integrator.Controllers
{
    public class PromoPackController : Controller
    {
        private IntegratorContext db = new IntegratorContext();

        // GET: /PromoPack/
        public ActionResult Index(int? id, int? packID)
        {
            var viewModel = new PromoPackIndexData();

            viewModel.PromoPacks = db.PromoPacks
                .Include(i => i.pack)
                .OrderBy(i => i.nombre);

            if (id != null)
            {
                ViewBag.PromoPackID = id.Value;
                viewModel.Pack = viewModel.PromoPacks.Where(
                    i => i.PromoID == id.Value).Single().pack;
            }
            if (packID != null)
            {
                ViewBag.PackID = packID.Value;
                viewModel.Pack = db.Packs.Find(packID);
            }
            return View(viewModel);
            //return View(db.PromoPacks.ToList());
        }

        // GET: /PromoPack/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoPack promopack = db.PromoPacks.Find(id);
            if (promopack == null)
            {
                return HttpNotFound();
            }
            return View(promopack);
        }

        // GET: /PromoPack/CreatePromoID
        public ActionResult Create()
        {
            //ViewBag.packs = new SelectList(db.Packs, "PackID", "nombre");
            populatePackList();
            return View();
            /*var promopack = new PromoPack();
            promopack.pack = new Pack();
            PopulatePackData(promopack);*/
            //return View();
        }

        // POST: /PromoPack/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for PromoID
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PromoID,nombre,PackID")] PromoPack pPromoPack)
        {
            ViewBag.err = 0;
            PromoPack ppck = new PromoPack();
            ppck.PromoID = pPromoPack.PromoID;
            ppck.nombre = pPromoPack.nombre;
            ppck.pack = db.Packs.Find(pPromoPack.PackID);
            if (ModelState.IsValid)
            {
                /*PromoPack ppck = new PromoPack();
                ppck.nombre = promopack.nombre;
                ppck.pack = db.Packs.Find(promopack.refPackID);*/

                //promopack.pack = db.Packs.Find(promopack.refPackID);
                //db.PromoPacks.Add(promopack);
                db.PromoPacks.Add(pPromoPack);
                
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Seleccione Pack.";
                ViewBag.err = 1;
            }

            //ViewBag.refPackID = new SelectList(db.Packs, "PromoID", "nombre", promopack.refPackID);
            //ViewBag.refPackID = new SelectList(db.Packs, "PackID", "nombre", promopackvw.refPackID);
            populatePackList(pPromoPack.PackID);
            return View(pPromoPack);

            /*
            if (selectedPack != null)
            {
                promopack.pack = new Pack();
                var packToAdd = db.Packs.Find(int.Parse(selectedPack));
                promopack.pack = packToAdd;
            }

            if (ModelState.IsValid)
            {
                db.Promos.Add(promopack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/

            //return View(promopack);
        }
        private void PopulatePackData(PromoPack promopack)
        {
            var allPacks = db.Packs;
            var viewModel = new List<Pack>();
            foreach (var pack in allPacks)
            {
                viewModel.Add(new Pack
                {
                    PackID = pack.PackID,
                    nombre = pack.nombre,
                    stock = pack.stock
                });
            }
            ViewBag.Packs = viewModel;
        }
        // GET: /PromoPack/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoPack promopack = db.PromoPacks.Find(id);
            if (promopack == null)
            {
                return HttpNotFound();
            }
            return View(promopack);
        }

        // POST: /PromoPack/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,nombre")] PromoPack promopack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promopack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promopack);
        }

        // GET: /PromoPack/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoPack promopack = db.PromoPacks.Find(id);
            if (promopack == null)
            {
                return HttpNotFound();
            }
            return View(promopack);
        }

        // POST: /PromoPack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PromoPack promopack = db.PromoPacks.Find(id);
            db.Promos.Remove(promopack);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private void populatePackList(object selectedPack = null)
        {
            /*var packsQuery = from p in db.Packs
                                   orderby p.nombre
                                   select p;*/
            IEnumerable<Pack> packs = db.Packs;

            ViewBag.PackID = new SelectList(packs, "PackID", "nombre", selectedPack);
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
