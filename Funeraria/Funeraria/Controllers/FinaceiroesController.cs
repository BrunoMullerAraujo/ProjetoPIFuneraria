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
    public class FinaceiroesController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: Finaceiroes
        public ActionResult Index()
        {
            var finaceiro = db.Finaceiro.Include(f => f.Conveniados);
            return View(finaceiro.ToList());
        }

        // GET: Finaceiroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finaceiro finaceiro = db.Finaceiro.Find(id);
            if (finaceiro == null)
            {
                return HttpNotFound();
            }
            return View(finaceiro);
        }

        // GET: Finaceiroes/Create
        public ActionResult Create()
        {
            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con");
            return View();
        }

        // POST: Finaceiroes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sequencia_fin,NumeroParcela_fin,Sequencia_con,DataVencimento_fin,DataPagamento_fin,ValorDebito_fin,ValorPago_fin")] Finaceiro finaceiro)
        {
            if (ModelState.IsValid)
            {
                db.Finaceiro.Add(finaceiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con", finaceiro.Sequencia_con);
            return View(finaceiro);
        }

        // GET: Finaceiroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finaceiro finaceiro = db.Finaceiro.Find(id);
            if (finaceiro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con", finaceiro.Sequencia_con);
            return View(finaceiro);
        }

        // POST: Finaceiroes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sequencia_fin,NumeroParcela_fin,Sequencia_con,DataVencimento_fin,DataPagamento_fin,ValorDebito_fin,ValorPago_fin")] Finaceiro finaceiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finaceiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con", finaceiro.Sequencia_con);
            return View(finaceiro);
        }

        // GET: Finaceiroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finaceiro finaceiro = db.Finaceiro.Find(id);
            if (finaceiro == null)
            {
                return HttpNotFound();
            }
            return View(finaceiro);
        }

        // POST: Finaceiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Finaceiro finaceiro = db.Finaceiro.Find(id);
            db.Finaceiro.Remove(finaceiro);
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
