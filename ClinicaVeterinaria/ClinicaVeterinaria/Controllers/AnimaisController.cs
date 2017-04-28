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
    public class AnimaisController : Controller
    {
        private VetsDB db = new VetsDB();

        // GET: Animais
        public ActionResult Index()
        {
            var animais = db.Animais.Include(a => a.Dono);
            return View(animais.ToList());
        }

        // GET: Animais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animais animais = db.Animais.Find(id);
            if (animais == null)
            {
                return HttpNotFound();
            }
            return View(animais);
        }

        // GET: Animais/Create
        public ActionResult Create()
        {
            ViewBag.DonosFK = new SelectList(db.Donos, "DonoID", "Nome");
            return View();
        }

        // POST: Animais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalID,Nome,Especie,Raca,Peso,Altura,DonosFK")] Animais animais)
        {
            if (ModelState.IsValid)
            {
                db.Animais.Add(animais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonosFK = new SelectList(db.Donos, "DonoID", "Nome", animais.DonosFK);
            return View(animais);
        }

        // GET: Animais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animais animais = db.Animais.Find(id);
            if (animais == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonosFK = new SelectList(db.Donos, "DonoID", "Nome", animais.DonosFK);
            return View(animais);
        }

        // POST: Animais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalID,Nome,Especie,Raca,Peso,Altura,DonosFK")] Animais animais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonosFK = new SelectList(db.Donos, "DonoID", "Nome", animais.DonosFK);
            return View(animais);
        }

        // GET: Animais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animais animais = db.Animais.Find(id);
            if (animais == null)
            {
                return HttpNotFound();
            }
            return View(animais);
        }

        // POST: Animais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animais animais = db.Animais.Find(id);
            db.Animais.Remove(animais);
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
