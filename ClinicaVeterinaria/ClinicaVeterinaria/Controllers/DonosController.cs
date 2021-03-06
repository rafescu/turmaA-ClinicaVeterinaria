﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Controllers {

    [Authorize] //força a que só utilizadores AUTENTICADOS consigam aceder aos métodos desta classe
                //aplica-se a TODOS os métodos
    public class DonosController : Controller {
        private VetsDB db = new VetsDB();

        // GET: Donos
        //[AllowAnonymous] //permite o acesso de utilizadores Anónimos aos conteúdos deste método, apenas deste.
        public ActionResult Index() {
            //mostra os dados apenas para os FUNCIONARIOS ou para os VETERINARIOS
            if (User.IsInRole("Veterinario") || User.IsInRole("Funcionario"))
            {
                
               return View(db.Donos.ToList().OrderBy(d => d.Nome)); 
            }
            //se chegar aqui, é porque é DONO
            return View(db.Donos.Where(d=>d.Username.Equals(User.Identity.Name)).ToList());
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
        public ActionResult Create([Bind(Include = "Nome,NIF")] Donos dono) {

            //determinar o ID a atribuir ao novo 'dono'
            int novoID = 0;
            try {
                //perguntar á BD qual o último DonoID
                novoID = db.Donos.Max(d => d.DonoID) + 1;
            } catch (Exception) {
                //não existe dados na BD
                //o MAX devolve NULL
                novoID = 1;
            }
            
            //outra forma
            //novoID = db.Donos.Last().DonoID + 1;
            //outra forma
            //novoID = (from d in db.Donos
            //          orderby d.DonoID descending
            //          select d.DonoID).FirstOrDefault() + 1;
            //outra forma
            //novoID = db.Donos.OrderByDescending(d => d.DonoID).FirstOrDefault().DonoID + 1;

            //atribuir o novo ID ao 'dono'
            dono.DonoID = novoID;
            try {
                if (ModelState.IsValid) { //confronta se os dados a ser introduzidos estão consistentes com o model

                                //adicionar um novo 'dono'
                                db.Donos.Add(dono);
                                //guardar as alteracoes
                                db.SaveChanges();
                                //redirecionar para a página de início
                                return RedirectToAction("Index");
                            }
            } catch (Exception ex) {
                ModelState.AddModelError("",
                    string.Format("Ocorreu um erro na operacão de guardar um novo Dono...")
                    );
                //adicionar a uma classe ERRO
                   //-id
                   //-timestamp
                   //-operacao que gerou o erro
                   //-mensagem de erro(ex.Message)
                   //-qual o utilizador que gerou o erro
                   //-...
                   //enviar email ao utilizador 'admin' a avisar da ocorrencia do erro
            }
            //se houver problemas, volta para a View do Create
            //com os dados do 'dono'
            return View(dono);
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
