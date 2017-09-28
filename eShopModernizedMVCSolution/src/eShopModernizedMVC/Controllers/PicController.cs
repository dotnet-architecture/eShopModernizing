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
        private static ImageFormat[] ValidFormats = new[] { ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Gif };
        private IImageService imageService;

        public PicController(ICatalogService service, IImageService imageService)
        {
            this.imageService = imageService;
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
