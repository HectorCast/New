using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EpamStudy.Models;

namespace EpamStudy.Controllers
{
    public class GasolinerasController : Controller
    {
        private autotransportesEPAMEntities db = new autotransportesEPAMEntities();

        // GET: Gasolineras
        public ActionResult Index()
        {
            return View(db.Gasolineras.ToList());
        }

        // GET: Gasolineras/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasolineras gasolineras = db.Gasolineras.Find(id);
            if (gasolineras == null)
            {
                return HttpNotFound();
            }
            return View(gasolineras);
        }

        // GET: Gasolineras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gasolineras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GasolineraID,RazonSocial,Ubicacion,IsActive")] Gasolineras gasolineras)
        {
            if (ModelState.IsValid)
            {
                db.Gasolineras.Add(gasolineras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gasolineras);
        }

        // GET: Gasolineras/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasolineras gasolineras = db.Gasolineras.Find(id);
            if (gasolineras == null)
            {
                return HttpNotFound();
            }
            return View(gasolineras);
        }

        // POST: Gasolineras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GasolineraID,RazonSocial,Ubicacion,IsActive")] Gasolineras gasolineras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasolineras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gasolineras);
        }

        // GET: Gasolineras/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasolineras gasolineras = db.Gasolineras.Find(id);
            if (gasolineras == null)
            {
                return HttpNotFound();
            }
            return View(gasolineras);
        }

        // POST: Gasolineras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Gasolineras gasolineras = db.Gasolineras.Find(id);
            db.Gasolineras.Remove(gasolineras);
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
