using Microsoft.AspNetCore.Http;
//using Microsoft.Azure.Storage.Blob;
//using Microsoft.Azure.Storage;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata;
using System.ComponentModel;

namespace MVCCore1.Services
{
    public class AzureService : IAzureService
    {
        public static int r1;
       
        public async Task<string>  uploadImage(IFormFile photo, string accessKey)
        {
            string imageFullPath = null;
            Random r = new Random();
            r1 = r.Next(1, 1000);

            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("jamesbond");

                //catch { }
                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    Task.WaitAll();
                    
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });
                }
                //finally
                //{
                    
                    string imageName = r1+ Path.GetFileName(photo.FileName);
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference("AnishaNew/" +imageName);
                    cloudBlockBlob.Properties.ContentType = photo.ContentType;

                    //Initiates an asynchronous operation to upload a stream to a block blob
                    //. If the blob already exists, it will be overwritten.
                    //using (var stream = photo.OpenReadStream())
                    //{
                        cloudBlockBlob.UploadFromStreamAsync(photo.OpenReadStream());
                        imageFullPath = cloudBlockBlob.Uri.ToString();
                    //}
                        //cloudBlockBlob.UploadFromStreamAsync(photo.OpenReadStream());

//                }




            }
            catch (Exception ex) { }
            
            return imageFullPath;
        }
    }
}
