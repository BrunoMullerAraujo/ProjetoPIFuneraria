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
    public class TabEstadoesController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: TabEstadoes
        public ActionResult Index()
        {
            return View(db.TabEstado.ToList());
        }

        // GET: TabEstadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabEstado tabEstado = db.TabEstado.Find(id);
            if (tabEstado == null)
            {
                return HttpNotFound();
            }
            return View(tabEstado);
        }

        // GET: TabEstadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TabEstadoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoUf_unf,DescricaoUf_unf")] TabEstado tabEstado)
        {
            if (ModelState.IsValid)
            {
                db.TabEstado.Add(tabEstado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabEstado);
        }

        // GET: TabEstadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabEstado tabEstado = db.TabEstado.Find(id);
            if (tabEstado == null)
            {
                return HttpNotFound();
            }
            return View(tabEstado);
        }

        // POST: TabEstadoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoUf_unf,DescricaoUf_unf")] TabEstado tabEstado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabEstado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabEstado);
        }

        // GET: TabEstadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabEstado tabEstado = db.TabEstado.Find(id);
            if (tabEstado == null)
            {
                return HttpNotFound();
            }
            return View(tabEstado);
        }

        // POST: TabEstadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabEstado tabEstado = db.TabEstado.Find(id);
            db.TabEstado.Remove(tabEstado);
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
