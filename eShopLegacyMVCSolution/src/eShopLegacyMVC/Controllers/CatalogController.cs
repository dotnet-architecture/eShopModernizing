using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using eShopLegacyMVC.Models;
using eShopLegacyMVC.Services;
using log4net;

namespace eShopLegacyMVC.Controllers
{
    public class CatalogController : Controller
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ICatalogService service;

        public CatalogController(ICatalogService service)
        {
            this.service = service;
        }

        // GET /[?pageSize=3&pageIndex=10]
        public ActionResult Index(int pageSize = 10, int pageIndex = 0)
        {
            _log.Info($"Now loading... /Catalog/Index?pageSize={pageSize}&pageIndex={pageIndex}");
            var paginatedItems = service.GetCatalogItemsPaginated(pageSize, pageIndex);
            ChangeUriPlaceholder(paginatedItems.Data);
            return View(paginatedItems);
        }

        // GET: Catalog/Details/5
        public ActionResult Details(int? id)
        {
            _log.Info($"Now loading... /Catalog/Details?id={id}");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = service.FindCatalogItem(id.Value);
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
            _log.Info($"Now loading... /Catalog/Create");
            ViewBag.CatalogBrandId = new SelectList(service.GetCatalogBrands(), "Id", "Brand");
            ViewBag.CatalogTypeId = new SelectList(service.GetCatalogTypes(), "Id", "Type");
            return View(new CatalogItem());
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PictureFileName,CatalogTypeId,CatalogBrandId,AvailableStock,RestockThreshold,MaxStockThreshold,OnReorder")] CatalogItem catalogItem)
        {
            _log.Info($"Now processing... /Catalog/Create?catalogItemName={catalogItem.Name}");
            if (ModelState.IsValid)
            {
                service.CreateCatalogItem(catalogItem);
                return RedirectToAction("Index");
            }

            ViewBag.CatalogBrandId = new SelectList(service.GetCatalogBrands(), "Id", "Brand", catalogItem.CatalogBrandId);
            ViewBag.CatalogTypeId = new SelectList(service.GetCatalogTypes(), "Id", "Type", catalogItem.CatalogTypeId);
            return View(catalogItem);
        }

        // GET: Catalog/Edit/5
        public ActionResult Edit(int? id)
        {
            _log.Info($"Now loading... /Catalog/Edit?id={id}");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = service.FindCatalogItem(id.Value);
            if (catalogItem == null)
            {
                return HttpNotFound();
            }
            AddUriPlaceHolder(catalogItem);
            ViewBag.CatalogBrandId = new SelectList(service.GetCatalogBrands(), "Id", "Brand", catalogItem.CatalogBrandId);
            ViewBag.CatalogTypeId = new SelectList(service.GetCatalogTypes(), "Id", "Type", catalogItem.CatalogTypeId);
            return View(catalogItem);
        }

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PictureFileName,CatalogTypeId,CatalogBrandId,AvailableStock,RestockThreshold,MaxStockThreshold,OnReorder")] CatalogItem catalogItem)
        {
            _log.Info($"Now processing... /Catalog/Edit?id={catalogItem.Id}");
            if (ModelState.IsValid)
            {
                service.UpdateCatalogItem(catalogItem);
                return RedirectToAction("Index");
            }
            ViewBag.CatalogBrandId = new SelectList(service.GetCatalogBrands(), "Id", "Brand", catalogItem.CatalogBrandId);
            ViewBag.CatalogTypeId = new SelectList(service.GetCatalogTypes(), "Id", "Type", catalogItem.CatalogTypeId);
            return View(catalogItem);
        }

        // GET: Catalog/Delete/5
        public ActionResult Delete(int? id)
        {
            _log.Info($"Now loading... /Catalog/Delete?id={id}");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = service.FindCatalogItem(id.Value);
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
            _log.Info($"Now processing... /Catalog/DeleteConfirmed?id={id}");
            CatalogItem catalogItem = service.FindCatalogItem(id);
            service.RemoveCatalogItem(catalogItem);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _log.Debug($"Now disposing");
            if (disposing)
            {
                service.Dispose();
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
            item.PictureUri = this.Url.RouteUrl(PicController.GetPicRouteName, new { catalogItemId = item.Id }, this.Request.Url.Scheme);            
        }
    }
}
