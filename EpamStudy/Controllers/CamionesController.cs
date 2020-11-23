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
    public class CamionesController : Controller
    {
        private autotransportesEPAMEntities db = new autotransportesEPAMEntities();

        // GET: Camiones
        public ActionResult Index()
        {
            return View(db.Camiones.ToList());
        }

        // GET: Camiones/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiones camiones = db.Camiones.Find(id);
            if (camiones == null)
            {
                return HttpNotFound();
            }
            return View(camiones);
        }

        // GET: Camiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SerialNumber,Placa,Modelo,Year,IsActive")] Camiones camiones)
        {
            if (ModelState.IsValid)
            {
                db.Camiones.Add(camiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(camiones);
        }

        // GET: Camiones/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiones camiones = db.Camiones.Find(id);
            if (camiones == null)
            {
                return HttpNotFound();
            }
            return View(camiones);
        }

        // POST: Camiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SerialNumber,Placa,Modelo,Year,IsActive")] Camiones camiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camiones);
        }

        // GET: Camiones/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiones camiones = db.Camiones.Find(id);
            if (camiones == null)
            {
                return HttpNotFound();
            }
            return View(camiones);
        }

        // POST: Camiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Camiones camiones = db.Camiones.Find(id);
            db.Camiones.Remove(camiones);
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
