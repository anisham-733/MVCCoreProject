using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVCCore1.Models
{
    public partial class Blobfiles
    {
        public string Id { get; set; }
        public string Filename { get; set; }
        public double Filesize { get; set; }
        public DateTime DateModified { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }

       
       // public  photo { get; set; }
    }
}
