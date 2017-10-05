using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using eShopModernizedMVC.Models;
using eShopModernizedMVC.Services;
using System.IO;
using System;
using Microsoft.Diagnostics.EventFlow;
using System.Diagnostics;

namespace eShopModernizedMVC.Controllers
{
    public class CatalogController : Controller
    {
        private ICatalogService _service;
        private IImageService _imageService;

        public CatalogController(ICatalogService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        // GET /[?pageSize=3&pageIndex=10]
        public ActionResult Index(int pageSize = 10, int pageIndex = 0)
        {
            var paginatedItems = _service.GetCatalogItemsPaginated(pageSize, pageIndex);
            ChangeUriPlaceholder(paginatedItems.Data);
            return View(paginatedItems);
        }

        // GET: Catalog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = _service.FindCatalogItem(id.Value);
            if (catalogItem == null)
            {
                return HttpNotFound();
            }
            AddUriPlaceHolder(catalogItem);

            return View(catalogItem);
        }

        // GET: Catalog/Create
        public ActionResult Create()
        {

            ViewBag.CatalogBrandId = new SelectList(_service.GetCatalogBrands(), "Id", "Brand");
            ViewBag.CatalogTypeId = new SelectList(_service.GetCatalogTypes(), "Id", "Type");
            ViewBag.UseAzureStorage = CatalogConfiguration.UseAzureStorage;

            return View(new CatalogItem()
            {
                PictureUri = _imageService.UrlDefaultImage()
            });
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PictureFileName,CatalogTypeId,CatalogBrandId,AvailableStock,RestockThreshold,MaxStockThreshold,OnReorder,TempImageName")] CatalogItem catalogItem)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(catalogItem.TempImageName))
                {
                    var fileName = Path.GetFileName(catalogItem.TempImageName);
                    catalogItem.PictureFileName = fileName;
                }

                _service.CreateCatalogItem(catalogItem);
                if (!string.IsNullOrEmpty(catalogItem.TempImageName))
                {
                    _imageService.UpdateImage(catalogItem);
                }
                return RedirectToAction("Index");
            }

            ViewBag.CatalogBrandId = new SelectList(_service.GetCatalogBrands(), "Id", "Brand", catalogItem.CatalogBrandId);
            ViewBag.CatalogTypeId = new SelectList(_service.GetCatalogTypes(), "Id", "Type", catalogItem.CatalogTypeId);
            ViewBag.UseAzureStorage = CatalogConfiguration.UseAzureStorage;
            return View(catalogItem);
        }

        // GET: Catalog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CatalogItem catalogItem = _service.FindCatalogItem(id.Value);

            if (catalogItem == null)
            {
                return HttpNotFound();
            }
            AddUriPlaceHolder(catalogItem);
            ViewBag.CatalogBrandId = new SelectList(_service.GetCatalogBrands(), "Id", "Brand", catalogItem.CatalogBrandId);
            ViewBag.CatalogTypeId = new SelectList(_service.GetCatalogTypes(), "Id", "Type", catalogItem.CatalogTypeId);
            ViewBag.UseAzureStorage = CatalogConfiguration.UseAzureStorage;
            return View(catalogItem);
        }

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PictureFileName,CatalogTypeId,CatalogBrandId,AvailableStock,RestockThreshold,MaxStockThreshold,OnReorder,TempImageName")] CatalogItem catalogItem)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(catalogItem.TempImageName))
                {
                    _imageService.UpdateImage(catalogItem);
                    var fileName = Path.GetFileName(catalogItem.TempImageName);
                    catalogItem.PictureFileName = fileName;
                }

                _service.UpdateCatalogItem(catalogItem);
                return RedirectToAction("Index");
            }
            ViewBag.CatalogBrandId = new SelectList(_service.GetCatalogBrands(), "Id", "Brand", catalogItem.CatalogBrandId);
            ViewBag.CatalogTypeId = new SelectList(_service.GetCatalogTypes(), "Id", "Type", catalogItem.CatalogTypeId);
            ViewBag.UseAzureStorage = CatalogConfiguration.UseAzureStorage;
            return View(catalogItem);
        }

        // GET: Catalog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = _service.FindCatalogItem(id.Value);
            if (catalogItem == null)
            {
                return HttpNotFound();
            }
            AddUriPlaceHolder(catalogItem);

            return View(catalogItem);
        }

        // POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatalogItem catalogItem = _service.FindCatalogItem(id);
            _service.RemoveCatalogItem(catalogItem);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ChangeUriPlaceholder(IEnumerable<CatalogItem> items)
        {
            foreach (var catalogItem in items)
            {
                AddUriPlaceHolder(catalogItem);
            }
        }

        private void AddUriPlaceHolder(CatalogItem item)
        {
            item.PictureUri = _imageService.BuildUrlImage(item);
        }



    }



}

