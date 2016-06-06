using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FacultetsController : Controller
    {
        private StudentSystemDbContext db = new StudentSystemDbContext();

        // GET: Facultets
        public ActionResult Index()
        {
            return View(db.Facultets.ToList());
        }

        // GET: Facultets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultet facultet = db.Facultets.Find(id);
            if (facultet == null)
            {
                return HttpNotFound();
            }
            return View(facultet);
        }

        // GET: Facultets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facultets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Facultet facultet)
        {
            if (ModelState.IsValid)
            {
                db.Facultets.Add(facultet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facultet);
        }

        // GET: Facultets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultet facultet = db.Facultets.Find(id);
            if (facultet == null)
            {
                return HttpNotFound();
            }
            return View(facultet);
        }

        // POST: Facultets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Facultet facultet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facultet);
        }

        // GET: Facultets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultet facultet = db.Facultets.Find(id);
            if (facultet == null)
            {
                return HttpNotFound();
            }
            return View(facultet);
        }

        // POST: Facultets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facultet facultet = db.Facultets.Find(id);
            db.Facultets.Remove(facultet);
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
