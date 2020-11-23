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
    public class ConductoresController : Controller
    {
        private autotransportesEPAMEntities db = new autotransportesEPAMEntities();

        // GET: Conductores
        public ActionResult Index()
        {
            return View(db.Conductores.ToList());
        }

        // GET: Conductores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductores conductores = db.Conductores.Find(id);
            if (conductores == null)
            {
                return HttpNotFound();
            }
            return View(conductores);
        }

        // GET: Conductores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conductores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Nombre,Apellido,Direccion,Telefono,BaseID,IsActive")] Conductores conductores)
        {
            if (ModelState.IsValid)
            {
                db.Conductores.Add(conductores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conductores);
        }

        // GET: Conductores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductores conductores = db.Conductores.Find(id);
            if (conductores == null)
            {
                return HttpNotFound();
            }
            return View(conductores);
        }

        // POST: Conductores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Nombre,Apellido,Direccion,Telefono,BaseID,IsActive")] Conductores conductores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conductores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conductores);
        }

        // GET: Conductores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductores conductores = db.Conductores.Find(id);
            if (conductores == null)
            {
                return HttpNotFound();
            }
            return View(conductores);
        }

        // POST: Conductores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Conductores conductores = db.Conductores.Find(id);
            db.Conductores.Remove(conductores);
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
