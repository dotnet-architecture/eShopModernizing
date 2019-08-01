using eShopModernizedMVC.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace eShopModernizedMVC.Services
{
    public class ImageAzureStorage : IImageService
    {

        private readonly CloudStorageAccount _storageAccount;

        public ImageAzureStorage()
        {
            _storageAccount = CloudStorageAccount.Parse(CatalogConfiguration.StorageConnectionString);
        }

        public string BaseUrl()
        {
            return _storageAccount.BlobStorageUri.PrimaryUri.ToString();
        }

        public string BuildUrlImage(CatalogItem item)
        {
            if (string.IsNullOrEmpty(item.PictureFileName))
                return UrlDefaultImage();

            return _storageAccount.BlobStorageUri.PrimaryUri + "pics/" + item.Id + "/" + item.PictureFileName;
        }

        public void Dispose()
        {
        }

        public void InitializeCatalogImages()
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("pics");

            container.CreateIfNotExists();

            BlobContainerPermissions permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
            container.SetPermissions(permissions);


            Parallel.ForEach(container.ListBlobs().Where(x => x is CloudBlob), x => ((CloudBlob)x).Delete());
            var webRoot = HttpContext.Current.Server.MapPath("~/Pics");

            for (int i = 1; i <= 12; i++)
            {
                var path = Path.Combine(webRoot, i + ".png");
                var blobName = i + "/" + i + ".png";
                UpLoadImageFromFile(container, blobName, path, "image/png");

            }
            var defaultImagePath = Path.Combine(webRoot, "default.png");
            UpLoadImageFromFile(container, "temp/default.png", defaultImagePath, "image/png");


        }

        public void UpdateImage(CatalogItem item)
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("pics");

            var folder = item.TempImageName.Replace("/pics/", string.Empty);

            CloudBlockBlob tempBlob = container.GetBlockBlobReference(folder);

            var blockBlobs = container.ListBlobs(prefix: item.Id + "/").OfType<CloudBlockBlob>();
            foreach (var blockBlob in blockBlobs)
            {
                blockBlob.Delete();
            }

            var fileName = Path.GetFileName(item.TempImageName);
            CloudBlockBlob imageBlob = container.GetBlockBlobReference(item.Id + "/" + fileName);

            imageBlob.StartCopy(tempBlob);
            tempBlob.Delete();
        }

        public string UploadTempImage(HttpPostedFile file, int? catalogItemId)
        {
            string path = catalogItemId.HasValue ? catalogItemId + "/temp/" : "temp/" + Guid.NewGuid().ToString() + "/";

            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("pics");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(path + file.FileName.ToLower());

            blockBlob.Properties.ContentType = file.ContentType;
            file.InputStream.Seek(0, SeekOrigin.Begin);
            blockBlob.UploadFromStream(file.InputStream);

            return blockBlob.Uri.ToString();
        }

        public string UrlDefaultImage()
        {
            return _storageAccount.BlobStorageUri.PrimaryUri + "pics/temp/default.png";
        }

        private void UpLoadImageFromFile(CloudBlobContainer container, string blobName, string filePath, string contentType)
        {
            var fileStream = File.OpenRead(filePath);
            fileStream.Seek(0, SeekOrigin.Begin);

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
            blockBlob.Properties.ContentType = contentType;
            blockBlob.UploadFromStream(fileStream);
        }


    }
}