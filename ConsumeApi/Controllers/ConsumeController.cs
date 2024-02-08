using Microsoft.AspNetCore.Mvc;
using MongoExample.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsumeApi.Controllers
{
    public class ConsumeController : Controller
    {
        public IActionResult Index()
        {
            List<StudentList> data = new List<StudentList>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                }
            }
            catch 
            {

            }
            return View();
        }
    }
}
