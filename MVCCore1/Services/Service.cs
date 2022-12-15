using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Options;
using MVCCore1.Models;
using MVCCore1.Repositories;
using MVCCore1.Services.AppConfig;


namespace MVCCore1.Services
{
    public class Service : IService
    {
        private readonly IOperations _Operations;
        private readonly IAzureService _AzureService;
        private readonly IOptions<AppSettings> _Options;
        public static string imagePath1 = null;
        
        public Service(IOperations operations, IOptions<AppSettings> options, IAzureService AzureService) 
        {
            _Operations = operations;
            _Options = options;
            _AzureService = AzureService;
        }

        public async Task uploadImage(IFormFile file)
        {

           
            string accessKey = _Options.Value.AccessKey;
           // string imagePath = null;
            if (file == null || (file != null && file.Length == 0))
            {
                //Response. ("<script>alert('Please select a file to upload');</script>");
            }
            else
            {
                var imagePath =  Task.Run(async () => await _AzureService.uploadImage(file, accessKey));
                imagePath.Wait();
                imagePath1 = imagePath.Result;
                //Task.WaitAll();
            }  
            
            
        }
        public async Task addNew(Blobfiles blobfiles,IFormFile file)
        {
            //business logic--before inserting data to db--all conditions and validations



                blobfiles.Id = AzureService.r1.ToString();
                blobfiles.Filename = file.FileName;
                blobfiles.Filesize = file.Length;
                blobfiles.DateModified = System.DateTime.Now;
                blobfiles.Path = imagePath1; 
                //adding to database
                _Operations.newFile(blobfiles);

                
            
            
        }
        public IEnumerable<Blobfiles> GetAllBlobs()
        {
            IEnumerable<Blobfiles> info = _Operations.GetBlobfiles();
            //var imgInfo = dbContext.blobfiles.ToList();
            var query = from img in info
                        select new Blobfiles
                        {
                            Id = img.Id,
                            Filename = img.Filename,
                            Filesize = img.Filesize,
                            DateModified = System.DateTime.Now,
                            Path = img.Path
                        };

            return query;


        }
    }
}
