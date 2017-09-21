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
    public class ConveniadosController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: Conveniados
        public ActionResult Index()
        {
            var conveniados = db.Conveniados.Include(c => c.Cidade).Include(c => c.TipoContrato);
            return View(conveniados.ToList());
        }

        // GET: Conveniados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conveniados conveniados = db.Conveniados.Find(id);
            if (conveniados == null)
            {
                return HttpNotFound();
            }
            return View(conveniados);
        }

        // GET: Conveniados/Create
        public ActionResult Create()
        {
            ViewBag.Sequencia_cid = new SelectList(db.Cidade, "Sequencia_cid", "Descricao_cid");
            ViewBag.Codigo_tco = new SelectList(db.TipoContrato, "Codigo_tco", "Descricao_tco");
            return View();
        }

        // POST: Conveniados/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sequencia_con,Descricao_con,Endereco_con,Numero_con,Bairro_con,Sequencia_cid,DataNasc_con,DataObto_con,Codigo_tco,Ativo_con")] Conveniados conveniados)
        {
            if (ModelState.IsValid)
            {
                db.Conveniados.Add(conveniados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sequencia_cid = new SelectList(db.Cidade, "Sequencia_cid", "Descricao_cid", conveniados.Sequencia_cid);
            ViewBag.Codigo_tco = new SelectList(db.TipoContrato, "Codigo_tco", "Descricao_tco", conveniados.Codigo_tco);
            return View(conveniados);
        }

        // GET: Conveniados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conveniados conveniados = db.Conveniados.Find(id);
            if (conveniados == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sequencia_cid = new SelectList(db.Cidade, "Sequencia_cid", "Descricao_cid", conveniados.Sequencia_cid);
            ViewBag.Codigo_tco = new SelectList(db.TipoContrato, "Codigo_tco", "Descricao_tco", conveniados.Codigo_tco);
            return View(conveniados);
        }

        // POST: Conveniados/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sequencia_con,Descricao_con,Endereco_con,Numero_con,Bairro_con,Sequencia_cid,DataNasc_con,DataObto_con,Codigo_tco,Ativo_con")] Conveniados conveniados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conveniados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sequencia_cid = new SelectList(db.Cidade, "Sequencia_cid", "Descricao_cid", conveniados.Sequencia_cid);
            ViewBag.Codigo_tco = new SelectList(db.TipoContrato, "Codigo_tco", "Descricao_tco", conveniados.Codigo_tco);
            return View(conveniados);
        }

        // GET: Conveniados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conveniados conveniados = db.Conveniados.Find(id);
            if (conveniados == null)
            {
                return HttpNotFound();
            }
            return View(conveniados);
        }

        // POST: Conveniados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conveniados conveniados = db.Conveniados.Find(id);
            db.Conveniados.Remove(conveniados);
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
