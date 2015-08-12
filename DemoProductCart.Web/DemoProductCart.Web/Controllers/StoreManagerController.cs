using ProductCart.Models.ActionResults;
using ProductCart.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProductCart.Web.Controllers
{
    public class StoreManagerController : Controller
    {
        private StoreEntities db = new StoreEntities();

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var albums = db.Products.Include(a => a.ProductCategory).Include(a => a.Manufacture);
            return View(albums.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            Product album = db.Products.Find(id);
            return View(album);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategorys, "ProductCategoryId", "Name");
            ViewBag.ManufactureId = new SelectList(db.Manufactures, "ManufactureId", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategoryId = new SelectList(db.ProductCategorys, "ProductCategoryId", "Name", product.ProductCategoryId);
            ViewBag.ManufactureId = new SelectList(db.Manufactures, "ManufactureId", "Name", product.ManufactureId);
            return View(product);
        }

        //
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategorys, "ProductCategoryId", "Name", product.ProductCategoryId);
            ViewBag.ManufactureId = new SelectList(db.Manufactures, "ManufactureId", "Name", product.ManufactureId);
            return View(product);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategorys, "ProductCategoryId", "Name", product.ProductCategoryId);
            ViewBag.ManufactureId = new SelectList(db.Manufactures, "ManufactureId", "Name", product.ManufactureId);
            return View(product);
        }

        //
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Download XML file
        /// </summary>
        /// <returns></returns>
        public ActionResult DownloadFile()
        {
            var XMLData = db.ProductCategorys.ToList();

            return new XmlResult<List<ProductCategory>>()
            {
                Data = XMLData
            };
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}