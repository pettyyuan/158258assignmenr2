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
using assignment2.View_Models;
using PagedList;
using static assignment2.View_Models.DishesIndexViewModel;

namespace assignment2.Controllers
{
    public class local_dishesController : Controller
    {
        private assignment2Context db = new assignment2Context();

        // GET: local_dishes
        public ActionResult Index(string cuisine, string search,int ?page)
        {

            DishesIndexViewModel viewModel = new DishesIndexViewModel();
            var product = db.local_dishes.Include(p => p.Cuisines);
            if (!String.IsNullOrEmpty(search))
          {
            product = product.Where(l => l.name.Contains(search) ||
             l.local.Contains(search) ||
             l.Cuisines.type.Contains(search));
 //ViewBag.Search = search;
             viewModel.Search = search;
 }
            viewModel.CuisWithCount = from matchingLocal_dishes in product
                                      where matchingLocal_dishes.Cuisinesid != null
                                      group matchingLocal_dishes by
                                      matchingLocal_dishes.Cuisines.type into cuiGroup
                                      select new CuisinesWithCount()
                                      {
                                          CuisinesName = cuiGroup.Key,
                                          DishesCount = cuiGroup.Count()
                                      };
            //ViewBag.Category = new SelectList(categories);
            //return View(products.ToList());
            if (!String.IsNullOrEmpty(cuisine))
            {
                product = product.Where(p => p.Cuisines.type == cuisine);
                viewModel.Cuisine = cuisine;
            }
            product = product.OrderBy(p => p.name);
            const int PageItem = 6;
            int currentPage = (page ?? 1);
            viewModel.Local_dishes= product.ToPagedList(currentPage,PageItem);
            return View(viewModel);
        }

        // GET: local_dishes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            local_dishes local_dishes = db.local_dishes.Find(id);
            if (local_dishes == null)
            {
                return HttpNotFound();
            }
            return View(local_dishes);
        }

        // GET: local_dishes/Create
        public ActionResult Create()
        {
            ViewBag.Cuisinesid = new SelectList(db.Cuisines, "Id", "type");
            return View();
        }

        // POST: local_dishes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,local,Cuisinesid")] local_dishes local_dishes)
        {
            if (ModelState.IsValid)
            {
                db.local_dishes.Add(local_dishes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cuisinesid = new SelectList(db.Cuisines, "Id", "type", local_dishes.Cuisinesid);
            return View(local_dishes);
        }

        // GET: local_dishes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            local_dishes local_dishes = db.local_dishes.Find(id);
            if (local_dishes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cuisinesid = new SelectList(db.Cuisines, "Id", "type", local_dishes.Cuisinesid);
            return View(local_dishes);
        }

        // POST: local_dishes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,local,Cuisinesid")] local_dishes local_dishes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(local_dishes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cuisinesid = new SelectList(db.Cuisines, "Id", "type", local_dishes.Cuisinesid);
            return View(local_dishes);
        }

        // GET: local_dishes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            local_dishes local_dishes = db.local_dishes.Find(id);
            if (local_dishes == null)
            {
                return HttpNotFound();
            }
            return View(local_dishes);
        }

        // POST: local_dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            local_dishes local_dishes = db.local_dishes.Find(id);
            db.local_dishes.Remove(local_dishes);
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
