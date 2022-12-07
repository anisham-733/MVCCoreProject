using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using MVCCore1.Models;
using System.IO;
using Microsoft.AspNetCore.Http;



namespace MVCCore1.Repositories
{
    public class Operations : IOperations
    {
        private readonly mydatabaseContext _mydatabaseContext;
        public Operations()
        {
            _mydatabaseContext= new mydatabaseContext();
        }
        public Operations(mydatabaseContext mydatabaseContext)
        {
            _mydatabaseContext= mydatabaseContext;
        }
        public void deleteFile(string Id)
        {
            Blobfiles existingFile = _mydatabaseContext.Blobfiles.Where(x => x.Id == Id).FirstOrDefault();
            _mydatabaseContext.Blobfiles.Remove(existingFile);
            _mydatabaseContext.SaveChanges();
            
        }

        public IEnumerable<Blobfiles> GetBlobfiles()
        {
            return _mydatabaseContext.Blobfiles.ToList();
            
        }

        public void newFile(Blobfiles blobfiles)
        {
            

            _mydatabaseContext.Blobfiles.Add(blobfiles);
            Save();
        }

        public void Save()
        {
            _mydatabaseContext.SaveChanges();
        }
    }
}
