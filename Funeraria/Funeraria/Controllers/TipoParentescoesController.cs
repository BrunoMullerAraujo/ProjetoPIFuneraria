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
    public class TipoParentescoesController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: TipoParentescoes
        public ActionResult Index()
        {
            return View(db.TipoParentesco.ToList());
        }

        // GET: TipoParentescoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoParentesco tipoParentesco = db.TipoParentesco.Find(id);
            if (tipoParentesco == null)
            {
                return HttpNotFound();
            }
            return View(tipoParentesco);
        }

        // GET: TipoParentescoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoParentescoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_par,Descricao_par")] TipoParentesco tipoParentesco)
        {
            if (ModelState.IsValid)
            {
                db.TipoParentesco.Add(tipoParentesco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoParentesco);
        }

        // GET: TipoParentescoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoParentesco tipoParentesco = db.TipoParentesco.Find(id);
            if (tipoParentesco == null)
            {
                return HttpNotFound();
            }
            return View(tipoParentesco);
        }

        // POST: TipoParentescoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_par,Descricao_par")] TipoParentesco tipoParentesco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoParentesco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoParentesco);
        }

        // GET: TipoParentescoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoParentesco tipoParentesco = db.TipoParentesco.Find(id);
            if (tipoParentesco == null)
            {
                return HttpNotFound();
            }
            return View(tipoParentesco);
        }

        // POST: TipoParentescoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoParentesco tipoParentesco = db.TipoParentesco.Find(id);
            db.TipoParentesco.Remove(tipoParentesco);
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
