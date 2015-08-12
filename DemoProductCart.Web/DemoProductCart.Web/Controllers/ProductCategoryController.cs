using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductCart.Models.Models;
using PagedList;

namespace DemoProductCart.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: /ProductCategory/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = db.ProductCategorys.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString)
                                       || s.Description.Contains(searchString)).ToList();
            }


            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Date":
                    products = products.OrderBy(s => s.Description).ToList();
                    break;
                case "date_desc":
                    products = products.OrderByDescending(s => s.Name).ToList();
                    break;
                default:  // Name ascending 
                    products = products.OrderBy(s => s.Description).ToList();
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));

            //return View(db.ProductCategorys.ToList());

            //return View(products);
        }

        // GET: /ProductCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productcategory = db.ProductCategorys.Find(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            return View(productcategory);
        }

        // GET: /ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ProductCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProductCategoryId,Name,Description")] ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategorys.Add(productcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productcategory);
        }

        // GET: /ProductCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productcategory = db.ProductCategorys.Find(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            return View(productcategory);
        }

        // POST: /ProductCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProductCategoryId,Name,Description")] ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productcategory);
        }

        // GET: /ProductCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productcategory = db.ProductCategorys.Find(id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            return View(productcategory);
        }

        // POST: /ProductCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategory productcategory = db.ProductCategorys.Find(id);
            db.ProductCategorys.Remove(productcategory);
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
