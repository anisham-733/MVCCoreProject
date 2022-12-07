using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCore1.Models;

namespace MVCCore1.Services

{
    public interface IService
    {
        
        Task  addNew(Blobfiles blobfiles,IFormFile file);
        Task uploadImage(IFormFile file);
    }
}
