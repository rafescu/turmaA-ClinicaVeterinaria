using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Controllers
{
    public class VeterinariosController : Controller
    {
        private VetsDB db = new VetsDB();

        // GET: Veterinarios
        public ActionResult Index()
        {
            return View(db.Veterinarios.ToList());
        }

        // GET: Veterinarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinarios veterinarios = db.Veterinarios.Find(id);
            if (veterinarios == null)
            {
                return HttpNotFound();
            }
            return View(veterinarios);
        }

        // GET: Veterinarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VeterinarioID,Nome,Rua,NumPorta,Andar,CodPostal,NIF,DataEntradaClinica,NumCedulaProf,DataInscOrdem,Faculdade")] Veterinarios veterinarios)
        {
            if (ModelState.IsValid)
            {
                db.Veterinarios.Add(veterinarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veterinarios);
        }

        // GET: Veterinarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinarios veterinarios = db.Veterinarios.Find(id);
            if (veterinarios == null)
            {
                return HttpNotFound();
            }
            return View(veterinarios);
        }

        // POST: Veterinarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VeterinarioID,Nome,Rua,NumPorta,Andar,CodPostal,NIF,DataEntradaClinica,NumCedulaProf,DataInscOrdem,Faculdade")] Veterinarios veterinarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veterinarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinarios);
        }

        // GET: Veterinarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinarios veterinarios = db.Veterinarios.Find(id);
            if (veterinarios == null)
            {
                return HttpNotFound();
            }
            return View(veterinarios);
        }

        // POST: Veterinarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veterinarios veterinarios = db.Veterinarios.Find(id);
            db.Veterinarios.Remove(veterinarios);
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
