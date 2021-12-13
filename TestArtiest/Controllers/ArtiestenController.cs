using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestArtiest.Data;
using TestArtiest.Models;

namespace TestArtiest.Controllers
{
    public class ArtiestenController : Controller
    {
        private MuziekContext db = new MuziekContext();

        // GET: Artiesten
        public ActionResult Index()
        {
            return View(db.Artiesten.ToList());
        }

        // GET: Artiesten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artiest artiest = db.Artiesten.Find(id);
            if (artiest == null)
            {
                return HttpNotFound();
            }
            return View(artiest);
        }

        // GET: Artiesten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artiesten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtiestId,Naam,AantalLuisteraars,Label")] Artiest artiest)
        {
            if (ModelState.IsValid)
            {
                db.Artiesten.Add(artiest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artiest);
        }

        // GET: Artiesten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artiest artiest = db.Artiesten.Find(id);
            if (artiest == null)
            {
                return HttpNotFound();
            }
            return View(artiest);
        }

        // POST: Artiesten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtiestId,Naam,AantalLuisteraars,Label")] Artiest artiest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artiest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artiest);
        }

        // GET: Artiesten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artiest artiest = db.Artiesten.Find(id);
            if (artiest == null)
            {
                return HttpNotFound();
            }
            return View(artiest);
        }

        // POST: Artiesten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artiest artiest = db.Artiesten.Find(id);
            db.Artiesten.Remove(artiest);
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
