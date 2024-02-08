using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ConsumeWebApi.Controllers
{
    public class StudentController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44397/api");
        private readonly HttpClient _client;

        public StudentController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/StudentList/Get").Result;
            if (response.IsSuccessStatusCode) 
            {
                string data = response.Content.ReadAsStringAsync().Result;
                studentList = JsonConvert.DeserializeObject<List<StudentViewModel>>(data);

            }
            return View(studentList);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel model) 
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/StudentList/Post", content).Result;
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

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                StudentViewModel student = new StudentViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/StudentList/Get" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    student = JsonConvert.DeserializeObject<StudentViewModel>(data);
                }
                return View(student);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel model) 
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "StudentList/Put", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Student details updated.";
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

        [HttpGet]
        public IActionResult Delete(int Id) 
        {
            try
            {
                StudentViewModel student = new StudentViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/StudentList/Get" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    student = JsonConvert.DeserializeObject<StudentViewModel>(data);
                }
                return View(student);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/StudentList/Delete/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Student details deleted.";
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
