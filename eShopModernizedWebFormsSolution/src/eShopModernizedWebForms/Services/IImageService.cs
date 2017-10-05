using eShopModernizedWebForms.Models;
using System;
using System.Web;

namespace eShopModernizedWebForms.Services
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
