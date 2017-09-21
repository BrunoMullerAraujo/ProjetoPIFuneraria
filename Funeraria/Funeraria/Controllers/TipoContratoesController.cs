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
    public class TipoContratoesController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: TipoContratoes
        public ActionResult Index()
        {
            return View(db.TipoContrato.ToList());
        }

        // GET: TipoContratoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContrato tipoContrato = db.TipoContrato.Find(id);
            if (tipoContrato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContrato);
        }

        // GET: TipoContratoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoContratoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_tco,Descricao_tco,ValorContrato_tco")] TipoContrato tipoContrato)
        {
            if (ModelState.IsValid)
            {
                db.TipoContrato.Add(tipoContrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoContrato);
        }

        // GET: TipoContratoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContrato tipoContrato = db.TipoContrato.Find(id);
            if (tipoContrato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContrato);
        }

        // POST: TipoContratoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_tco,Descricao_tco,ValorContrato_tco")] TipoContrato tipoContrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoContrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoContrato);
        }

        // GET: TipoContratoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContrato tipoContrato = db.TipoContrato.Find(id);
            if (tipoContrato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContrato);
        }

        // POST: TipoContratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoContrato tipoContrato = db.TipoContrato.Find(id);
            db.TipoContrato.Remove(tipoContrato);
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
