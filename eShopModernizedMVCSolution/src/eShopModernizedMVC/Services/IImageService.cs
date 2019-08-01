using eShopModernizedMVC.Models;
using System;
using System.Web;

namespace eShopModernizedMVC.Services
{
    public interface IImageService: IDisposable
    {
        string UploadTempImage(HttpPostedFile file, int? catalogItemId);
        string BaseUrl();
        void UpdateImage(CatalogItem item);
        string UrlDefaultImage();
        string BuildUrlImage(CatalogItem item);
        void InitializeCatalogImages();
    }
}
