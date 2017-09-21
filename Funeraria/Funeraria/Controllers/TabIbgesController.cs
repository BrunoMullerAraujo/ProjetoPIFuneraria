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
    public class TabIbgesController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: TabIbges
        public ActionResult Index()
        {
            return View(db.TabIbge.ToList());
        }

        // GET: TabIbges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabIbge tabIbge = db.TabIbge.Find(id);
            if (tabIbge == null)
            {
                return HttpNotFound();
            }
            return View(tabIbge);
        }

        // GET: TabIbges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TabIbges/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoIbge_ibg,DescricaoIbge_ibg")] TabIbge tabIbge)
        {
            if (ModelState.IsValid)
            {
                db.TabIbge.Add(tabIbge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabIbge);
        }

        // GET: TabIbges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabIbge tabIbge = db.TabIbge.Find(id);
            if (tabIbge == null)
            {
                return HttpNotFound();
            }
            return View(tabIbge);
        }

        // POST: TabIbges/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoIbge_ibg,DescricaoIbge_ibg")] TabIbge tabIbge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabIbge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabIbge);
        }

        // GET: TabIbges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabIbge tabIbge = db.TabIbge.Find(id);
            if (tabIbge == null)
            {
                return HttpNotFound();
            }
            return View(tabIbge);
        }

        // POST: TabIbges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabIbge tabIbge = db.TabIbge.Find(id);
            db.TabIbge.Remove(tabIbge);
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
