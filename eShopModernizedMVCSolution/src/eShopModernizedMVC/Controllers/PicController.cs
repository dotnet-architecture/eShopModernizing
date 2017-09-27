using eShopModernizedMVC.Services;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace eShopModernizedMVC.Controllers
{
    public class PicController : Controller
    {
        public const string GetPicRouteName = "GetPicRouteTemplate";
        private static ImageFormat[] ValidFormats = new[] { ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Gif };


        private ICatalogService service;
        private IImageService imageService;

        public PicController(ICatalogService service, IImageService imageService)
        {
            this.service = service;
            this.imageService = imageService;
        }

        // GET: Pic/5.png
        [HttpGet]
        [Route("items/{catalogItemId:int}/pic", Name = GetPicRouteName)]
        public ActionResult Index(int catalogItemId)
        {
            if (catalogItemId <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = service.FindCatalogItem(catalogItemId);

            if (item != null)
            {
                var webRoot = Server.MapPath("~/Pics");
                var path = Path.Combine(webRoot, item.PictureFileName);

                string imageFileExtension = Path.GetExtension(item.PictureFileName);
                string mimetype = GetImageMimeTypeFromImageFileExtension(imageFileExtension);

                var buffer = System.IO.File.ReadAllBytes(path);

                return File(buffer, mimetype);
            }

            return HttpNotFound();
        }


        [HttpPost]
        [Route("uploadimage")]
        public ActionResult UploadImage()
        {
            HttpPostedFile image = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
            var itemId = System.Web.HttpContext.Current.Request.Form["itemId"];

            if (!IsValidImage(image))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "image is not valid");
            }

            int.TryParse(itemId, out var catalogItemId);
            var urlImageTemp = imageService.UploadTempImage(image, catalogItemId);
            var tempImage = new
            {
                name = new Uri(urlImageTemp).PathAndQuery,
                url = urlImageTemp
            };

            return Json(tempImage);
        }

        private string GetImageMimeTypeFromImageFileExtension(string extension)
        {
            string mimetype;

            switch (extension)
            {
                case ".png":
                    mimetype = "image/png";
                    break;
                case ".gif":
                    mimetype = "image/gif";
                    break;
                case ".jpg":
                case ".jpeg":
                    mimetype = "image/jpeg";
                    break;
                case ".bmp":
                    mimetype = "image/bmp";
                    break;
                case ".tiff":
                    mimetype = "image/tiff";
                    break;
                case ".wmf":
                    mimetype = "image/wmf";
                    break;
                case ".jp2":
                    mimetype = "image/jp2";
                    break;
                case ".svg":
                    mimetype = "image/svg+xml";
                    break;
                default:
                    mimetype = "application/octet-stream";
                    break;
            }

            return mimetype;
        }

        private bool IsValidImage(HttpPostedFile file)
        {
            bool isValidImage = true;
            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    isValidImage = ValidFormats.Contains(img.RawFormat);
                }
            }
            catch (Exception)
            {
                isValidImage = false;
            }

            return isValidImage;
        }


    }
}
