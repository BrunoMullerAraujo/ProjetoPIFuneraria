using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Funeraria;

namespace Funeraria.Views
{
    public class DependentesController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: Dependentes
        public ActionResult Index()
        {
            var dependentes = db.Dependentes.Include(d => d.Conveniados).Include(d => d.TipoParentesco);
            return View(dependentes.ToList());
        }

        // GET: Dependentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dependentes dependentes = db.Dependentes.Find(id);
            if (dependentes == null)
            {
                return HttpNotFound();
            }
            return View(dependentes);
        }

        // GET: Dependentes/Create
        public ActionResult Create()
        {
            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con");
            ViewBag.Codigo_par = new SelectList(db.TipoParentesco, "Codigo_par", "Descricao_par");
            return View();
        }

        // POST: Dependentes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sequencia_dep,Sequencia_con,Descricao_dep,DataObto_dep,DataNasc_dep,Codigo_par")] Dependentes dependentes)
        {
            if (ModelState.IsValid)
            {
                db.Dependentes.Add(dependentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con", dependentes.Sequencia_con);
            ViewBag.Codigo_par = new SelectList(db.TipoParentesco, "Codigo_par", "Descricao_par", dependentes.Codigo_par);
            return View(dependentes);
        }

        // GET: Dependentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dependentes dependentes = db.Dependentes.Find(id);
            if (dependentes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con", dependentes.Sequencia_con);
            ViewBag.Codigo_par = new SelectList(db.TipoParentesco, "Codigo_par", "Descricao_par", dependentes.Codigo_par);
            return View(dependentes);
        }

        // POST: Dependentes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sequencia_dep,Sequencia_con,Descricao_dep,DataObto_dep,DataNasc_dep,Codigo_par")] Dependentes dependentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dependentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con", dependentes.Sequencia_con);
            ViewBag.Codigo_par = new SelectList(db.TipoParentesco, "Codigo_par", "Descricao_par", dependentes.Codigo_par);
            return View(dependentes);
        }

        // GET: Dependentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dependentes dependentes = db.Dependentes.Find(id);
            if (dependentes == null)
            {
                return HttpNotFound();
            }
            return View(dependentes);
        }

        // POST: Dependentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dependentes dependentes = db.Dependentes.Find(id);
            db.Dependentes.Remove(dependentes);
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
