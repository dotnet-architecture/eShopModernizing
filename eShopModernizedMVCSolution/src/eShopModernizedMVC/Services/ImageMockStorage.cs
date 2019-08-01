using System.Web;
using eShopModernizedMVC.Models;
using System.IO;

namespace eShopModernizedMVC.Services
{
    public class ImageMockStorage : IImageService
    {
        public string BaseUrl()
        {
            return GetBaseUrlImages();
        }

        public string BuildUrlImage(CatalogItem item)
        {
            var pictureFileName = string.IsNullOrEmpty(item.PictureFileName) ? "default.png" : item.PictureFileName;
            return GetBaseUrlImages() + pictureFileName;
        }

        public void Dispose()
        {

        }

        public void InitializeCatalogImages()
        {

        }

        public void UpdateImage(CatalogItem item)
        {

        }

        public string UploadTempImage(HttpPostedFile file, int? catalogItemId)
        {
            if (!catalogItemId.HasValue)
                return UrlDefaultImage();

            var pathPics = HttpContext.Current.Server.MapPath("~/Pics");
            var imageExists = File.Exists(Path.Combine(pathPics, catalogItemId.Value + ".png"));

            if (imageExists)
                return BaseUrl() + catalogItemId.Value + ".png";


            return UrlDefaultImage();
        }

        public string UrlDefaultImage()
        {
            return GetBaseUrlImages() + "default.png";
        }

        private string GetBaseUrlImages()
        {
            return "/Pics/";
        }
    }
}