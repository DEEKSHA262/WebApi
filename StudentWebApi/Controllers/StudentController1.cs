using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;
using Newtonsoft.Json;
using System.Text;

namespace StudentWebApi.Controllers
{
    public class StudentController1 : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44397/api");
        private readonly HttpClient _client;

        public StudentController1()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ViewModel> studentList = new List<ViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Student/Get").Result;
            if (response.IsSuccessStatusCode) 
            {
                string data = response.Content.ReadAsStringAsync().Result;
                studentList = JsonConvert.DeserializeObject<List<ViewModel>>(data);
            }
            return View(studentList);
        }

        [HttpGet]
        public IActionResult Create() 
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(ViewModel model) 
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Student/Post", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Student Created.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            
            return View();
        }
    }
}
