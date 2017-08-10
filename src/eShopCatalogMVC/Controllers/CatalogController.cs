using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eShopCatalogMVC.Models;

namespace eShopCatalogMVC.Controllers
{
    public class CatalogController : Controller
    {
        private CatalogDBContext db = new CatalogDBContext();

        // GET: Catalog
        public ActionResult Index()
        {
            var catalogItems = db.CatalogItems.Include(c => c.CatalogBrand).Include(c => c.CatalogType);
            return View(catalogItems.ToList());
        }

        // GET: Catalog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = db.CatalogItems.Find(id);
            if (catalogItem == null)
            {
                return HttpNotFound();
            }
            return View(catalogItem);
        }

        // GET: Catalog/Create
        public ActionResult Create()
        {
            ViewBag.CatalogBrandId = new SelectList(db.CatalogBrands, "Id", "Brand");
            ViewBag.CatalogTypeId = new SelectList(db.CatalogTypes, "Id", "Type");
            return View();
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PictureFileName,PictureUri,CatalogTypeId,CatalogBrandId,AvailableStock,RestockThreshold,MaxStockThreshold,OnReorder")] CatalogItem catalogItem)
        {
            if (ModelState.IsValid)
            {
                db.CatalogItems.Add(catalogItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatalogBrandId = new SelectList(db.CatalogBrands, "Id", "Brand", catalogItem.CatalogBrandId);
            ViewBag.CatalogTypeId = new SelectList(db.CatalogTypes, "Id", "Type", catalogItem.CatalogTypeId);
            return View(catalogItem);
        }

        // GET: Catalog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = db.CatalogItems.Find(id);
            if (catalogItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatalogBrandId = new SelectList(db.CatalogBrands, "Id", "Brand", catalogItem.CatalogBrandId);
            ViewBag.CatalogTypeId = new SelectList(db.CatalogTypes, "Id", "Type", catalogItem.CatalogTypeId);
            return View(catalogItem);
        }

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PictureFileName,PictureUri,CatalogTypeId,CatalogBrandId,AvailableStock,RestockThreshold,MaxStockThreshold,OnReorder")] CatalogItem catalogItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatalogBrandId = new SelectList(db.CatalogBrands, "Id", "Brand", catalogItem.CatalogBrandId);
            ViewBag.CatalogTypeId = new SelectList(db.CatalogTypes, "Id", "Type", catalogItem.CatalogTypeId);
            return View(catalogItem);
        }

        // GET: Catalog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = db.CatalogItems.Find(id);
            if (catalogItem == null)
            {
                return HttpNotFound();
            }
            return View(catalogItem);
        }

        // POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatalogItem catalogItem = db.CatalogItems.Find(id);
            db.CatalogItems.Remove(catalogItem);
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
