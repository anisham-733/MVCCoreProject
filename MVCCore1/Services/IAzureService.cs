using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVCCore1.Services
{
    public interface IAzureService
    {
         Task<string>  uploadImage(IFormFile photo, string accessKey);
    }
}
