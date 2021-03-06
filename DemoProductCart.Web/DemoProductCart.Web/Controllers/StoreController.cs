﻿using ProductCart.Models.ActionResults;
using ProductCart.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProductCart.Web.Controllers
{
    public class StoreController : Controller
    {
        StoreEntities storeDB = new StoreEntities();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.ProductCategorys.ToList();

            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string category)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.ProductCategorys.Include("Products")
                .Single(g => g.Name == category);

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var product = storeDB.Products.Find(id);

            return View(product);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.ProductCategorys.ToList();

            return PartialView(genres);
        }

        /// <summary>
        /// Download XML file
        /// </summary>
        /// <returns></returns>
        public ActionResult DownloadFile()
        {
            var XMLData = storeDB.Products.ToList();

            return new XmlResult<List<Product>>()
            {
                Data = XMLData
            };
        }

    }
}