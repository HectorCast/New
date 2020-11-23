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
    public class ViajesController : Controller
    {
        private autotransportesEPAMEntities db = new autotransportesEPAMEntities();

        // GET: Viajes
        public ActionResult Index()
        {
            var viajes = db.Viajes.Include(v => v.Camiones).Include(v => v.Conductores).Include(v => v.Rutas);
            return View(viajes.ToList());
        }

        // GET: Viajes/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajes viajes = db.Viajes.Find(id);
            if (viajes == null)
            {
                return HttpNotFound();
            }
            return View(viajes);
        }

        // GET: Viajes/Create
        public ActionResult Create()
        {
            ViewBag.SerialNumber = new SelectList(db.Camiones, "SerialNumber", "Placa");
            ViewBag.EmployeeID = new SelectList(db.Conductores, "EmployeeID", "Nombre");
            ViewBag.RutaID = new SelectList(db.Rutas, "RutaID", "Origen");
            return View();
        }

        // POST: Viajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ViajeID,SerialNumber,EmployeeID,RutaID,IsActive")] Viajes viajes)
        {
            if (ModelState.IsValid)
            {
                db.Viajes.Add(viajes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SerialNumber = new SelectList(db.Camiones, "SerialNumber", "Placa", viajes.SerialNumber);
            ViewBag.EmployeeID = new SelectList(db.Conductores, "EmployeeID", "Nombre", viajes.EmployeeID);
            ViewBag.RutaID = new SelectList(db.Rutas, "RutaID", "Origen", viajes.RutaID);
            return View(viajes);
        }

        // GET: Viajes/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajes viajes = db.Viajes.Find(id);
            if (viajes == null)
            {
                return HttpNotFound();
            }
            ViewBag.SerialNumber = new SelectList(db.Camiones, "SerialNumber", "Placa", viajes.SerialNumber);
            ViewBag.EmployeeID = new SelectList(db.Conductores, "EmployeeID", "Nombre", viajes.EmployeeID);
            ViewBag.RutaID = new SelectList(db.Rutas, "RutaID", "Origen", viajes.RutaID);
            return View(viajes);
        }

        // POST: Viajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ViajeID,SerialNumber,EmployeeID,RutaID,IsActive")] Viajes viajes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viajes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SerialNumber = new SelectList(db.Camiones, "SerialNumber", "Placa", viajes.SerialNumber);
            ViewBag.EmployeeID = new SelectList(db.Conductores, "EmployeeID", "Nombre", viajes.EmployeeID);
            ViewBag.RutaID = new SelectList(db.Rutas, "RutaID", "Origen", viajes.RutaID);
            return View(viajes);
        }

        // GET: Viajes/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajes viajes = db.Viajes.Find(id);
            if (viajes == null)
            {
                return HttpNotFound();
            }
            return View(viajes);
        }

        // POST: Viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Viajes viajes = db.Viajes.Find(id);
            db.Viajes.Remove(viajes);
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
