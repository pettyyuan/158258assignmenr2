using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assignment2.Data;
using assignment2.Models;

namespace assignment2.Controllers
{
    public class CuisinesController : Controller
    {
        private assignment2Context db = new assignment2Context();

        // GET: Cuisines
        public ActionResult Index()
        {
            return View(db.Cuisines.OrderBy(c => c.type).ToList());
        }

        // GET: Cuisines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuisines cuisines = db.Cuisines.Find(id);
            if (cuisines == null)
            {
                return HttpNotFound();
            }
            return View(cuisines);
        }

        // GET: Cuisines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cuisines/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,type")] Cuisines cuisines)
        {
            if (ModelState.IsValid)
            {
                db.Cuisines.Add(cuisines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cuisines);
        }

        // GET: Cuisines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuisines cuisines = db.Cuisines.Find(id);
            if (cuisines == null)
            {
                return HttpNotFound();
            }
            return View(cuisines);
        }

        // POST: Cuisines/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,type")] Cuisines cuisines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuisines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuisines);
        }

        // GET: Cuisines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuisines cuisines = db.Cuisines.Find(id);
            if (cuisines == null)
            {
                return HttpNotFound();
            }
            return View(cuisines);
        }

        // POST: Cuisines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuisines cuisines = db.Cuisines.Find(id);
            db.Cuisines.Remove(cuisines);
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
