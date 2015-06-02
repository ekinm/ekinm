using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using blog_deneme.Veritabani;
using PagedList;
using PagedList.Mvc;

namespace blog_deneme.Controllers
{
    public class MakalesController : Controller
    {
        private blogContext db = new blogContext();

        // GET: Makales
        public ActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == "Icerik")
            {
                return View(db.Makale.Where(x => x.Icerik == search || search == null).ToList().ToPagedList(page ?? 1, 2));
            }

            else
            {
                return View(db.Makale.Where(x => x.Baslik.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 2));
            }


        }

        // GET: Makales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makale.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // GET: Makales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Makales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Baslik,Ozet,Icerik,Tarih,Url")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Makale.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(makale);
        }

        // GET: Makales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makale.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: Makales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Baslik,Ozet,Icerik,Tarih,Url")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(makale);
        }

        // GET: Makales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makale.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: Makales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makale makale = db.Makale.Find(id);
            db.Makale.Remove(makale);
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
