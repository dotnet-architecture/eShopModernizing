using Autofac;
using Autofac.Integration.Web;
using eShopModernizedWebForms.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace eShopModernizedWebForms.Catalog
{
    /// <summary>
    /// Summary description for PicUploader
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class PicUploader : WebService
    {
        private static ImageFormat[] ValidFormats = new[] { ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Gif };

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UploadImage()
        {
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;
            IImageService imageService = cp.RequestLifetime.Resolve<IImageService>();

            HttpPostedFile image = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
            var itemId = System.Web.HttpContext.Current.Request.Form["itemId"];

            if (!IsValidImage(image))
            {
                Context.Response.StatusCode = 400;
                Context.Response.StatusDescription = "image is not valid";
                Context.Response.End();
                return;
            }

            int.TryParse(itemId, out var catalogItemId);
            var urlImageTemp = imageService.UploadTempImage(image, catalogItemId);
            var tempImage = new
            {
                name = new Uri(urlImageTemp).PathAndQuery,
                url = urlImageTemp
            };
            var js = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(tempImage));
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
