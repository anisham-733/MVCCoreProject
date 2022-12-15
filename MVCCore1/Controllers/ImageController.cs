using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Http;
using MVCCore1.Models;
using MVCCore1.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;


namespace MVCCore1.Controllers
{
    public class ImageController : Controller
    {
        private readonly IService _Service;

        public ImageController(IService service)
        {
            _Service = service;
        }
        public IActionResult Index()
        {
            return (IActionResult)View();
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> add(Blobfiles blobfiles,IFormFile photo)
        {
            //blobfiles.Filename = Path.GetFileName(p.fi);
            
            _Service.uploadImage(photo);
            //service class to upload image url to database
            _Service.addNew(blobfiles,photo);
            
            return RedirectToAction("list");
           
        }
        public IActionResult list()
        {
            return View(_Service.GetAllBlobs());
        }
        
    }
}
