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
    public class RegistroObtoesController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: RegistroObtoes
        public ActionResult Index()
        {
            var registroObto = db.RegistroObto.Include(r => r.Cidade).Include(r => r.Conveniados);
            return View(registroObto.ToList());
        }

        // GET: RegistroObtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroObto registroObto = db.RegistroObto.Find(id);
            if (registroObto == null)
            {
                return HttpNotFound();
            }
            return View(registroObto);
        }

        // GET: RegistroObtoes/Create
        public ActionResult Create()
        {
            ViewBag.Sequencia_cid = new SelectList(db.Cidade, "Sequencia_cid", "Descricao_cid");
            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con");
            return View();
        }

        // POST: RegistroObtoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sequencia_obt,Sequencia_con,DataObto_obt,LocalObtio_obt,Sequencia_cid")] RegistroObto registroObto)
        {
            if (ModelState.IsValid)
            {
                db.RegistroObto.Add(registroObto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sequencia_cid = new SelectList(db.Cidade, "Sequencia_cid", "Descricao_cid", registroObto.Sequencia_cid);
            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con", registroObto.Sequencia_con);
            return View(registroObto);
        }

        // GET: RegistroObtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroObto registroObto = db.RegistroObto.Find(id);
            if (registroObto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sequencia_cid = new SelectList(db.Cidade, "Sequencia_cid", "Descricao_cid", registroObto.Sequencia_cid);
            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con", registroObto.Sequencia_con);
            return View(registroObto);
        }

        // POST: RegistroObtoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sequencia_obt,Sequencia_con,DataObto_obt,LocalObtio_obt,Sequencia_cid")] RegistroObto registroObto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroObto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sequencia_cid = new SelectList(db.Cidade, "Sequencia_cid", "Descricao_cid", registroObto.Sequencia_cid);
            ViewBag.Sequencia_con = new SelectList(db.Conveniados, "Sequencia_con", "Descricao_con", registroObto.Sequencia_con);
            return View(registroObto);
        }

        // GET: RegistroObtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroObto registroObto = db.RegistroObto.Find(id);
            if (registroObto == null)
            {
                return HttpNotFound();
            }
            return View(registroObto);
        }

        // POST: RegistroObtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroObto registroObto = db.RegistroObto.Find(id);
            db.RegistroObto.Remove(registroObto);
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
