using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Controllers {
    public class DonosController : Controller {
        private VetsDB db = new VetsDB();

        // GET: Donos
        public ActionResult Index() {
            return View(db.Donos.ToList().OrderBy(d => d.Nome));
        }

        // GET: Donos/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donos donos = db.Donos.Find(id);
            if (donos == null) {
                return HttpNotFound();
            }
            return View(donos);
        }

        // GET: Donos/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Donos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonoID,Nome,NIF")] Donos donos) {
            if (ModelState.IsValid) {
                db.Donos.Add(donos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donos);
        }

        // GET: Donos/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donos donos = db.Donos.Find(id);
            if (donos == null) {
                return HttpNotFound();
            }
            return View(donos);
        }

        // POST: Donos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonoID,Nome,NIF")] Donos donos) {
            if (ModelState.IsValid) {
                db.Entry(donos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donos);
        }

        // GET: Donos/Delete/5
        public ActionResult Delete(int? id) {
            //se nao foi fornecido o ID do 'Dono'
            if (id == null) {
                //redireciono o utilizador para a lista de Donos
                return RedirectToAction("Index");
                
            }
            // vai a procura do 'Dono', cujo ID foi fornecido
            Donos dono = db.Donos.Find(id);
            //se o 'Dono' associado ao ID fornecido nao existe
            if (dono == null) {
                //redireciono o utilizador para a lista de Donos
                return RedirectToAction("Index");
                
            }
            //mostra os dados do 'Dono'
            return View(dono);
        }

        // POST: Donos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {

            //procura o 'dono' na base de dados
            Donos dono = db.Donos.Find(id);
            try {

                //marcar o 'dono' para eliminacao
                db.Donos.Remove(dono);
                //efetuar um 'commit' ao comando anterior
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception) {
                //criar uma mensagem de erro
                //a ser apresentada ao utilizador

                ModelState.AddModelError("",
                    string.Format("Ocorreu um erro na eliminacao do Dono com ID={0}-{1}", id, dono.Nome)
                    );
                //invoca a view, com os dados do 'Dono' atual
                return View(dono);
            }

        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
