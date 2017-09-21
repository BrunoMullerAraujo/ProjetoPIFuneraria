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
    public class CidadesController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: Cidades
        public ActionResult Index()
        {
            var cidade = db.Cidade.Include(c => c.TabEstado).Include(c => c.TabIbge);
            return View(cidade.ToList());
        }

        // GET: Cidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: Cidades/Create
        public ActionResult Create()
        {
            ViewBag.CodigoUf_unf = new SelectList(db.TabEstado, "CodigoUf_unf", "DescricaoUf_unf");
            ViewBag.CodigoIbge_ibg = new SelectList(db.TabIbge, "CodigoIbge_ibg", "DescricaoIbge_ibg");
            return View();
        }

        // POST: Cidades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sequencia_cid,Descricao_cid,CodigoUf_unf,CodigoIbge_ibg")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidade.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoUf_unf = new SelectList(db.TabEstado, "CodigoUf_unf", "DescricaoUf_unf", cidade.CodigoUf_unf);
            ViewBag.CodigoIbge_ibg = new SelectList(db.TabIbge, "CodigoIbge_ibg", "DescricaoIbge_ibg", cidade.CodigoIbge_ibg);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoUf_unf = new SelectList(db.TabEstado, "CodigoUf_unf", "DescricaoUf_unf", cidade.CodigoUf_unf);
            ViewBag.CodigoIbge_ibg = new SelectList(db.TabIbge, "CodigoIbge_ibg", "DescricaoIbge_ibg", cidade.CodigoIbge_ibg);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sequencia_cid,Descricao_cid,CodigoUf_unf,CodigoIbge_ibg")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoUf_unf = new SelectList(db.TabEstado, "CodigoUf_unf", "DescricaoUf_unf", cidade.CodigoUf_unf);
            ViewBag.CodigoIbge_ibg = new SelectList(db.TabIbge, "CodigoIbge_ibg", "DescricaoIbge_ibg", cidade.CodigoIbge_ibg);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cidade cidade = db.Cidade.Find(id);
            db.Cidade.Remove(cidade);
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
