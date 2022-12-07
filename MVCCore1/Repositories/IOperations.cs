using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using MVCCore1.Models;

namespace MVCCore1.Repositories
{
    public interface IOperations
    {
        IEnumerable<Blobfiles> GetBlobfiles();
       // public HttpPostedFileBase photo { get; set; }
        public void newFile(Blobfiles blobfiles);
        public void deleteFile(string Id);
        public void Save();


    }
}
