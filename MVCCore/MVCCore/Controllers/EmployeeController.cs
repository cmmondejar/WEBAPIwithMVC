using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MVCCore.Controllers
{
    public class EmployeeController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        TimeTracking _Employee = new TimeTracking();
        EditTimeTracking _EditEmployee = new EditTimeTracking();
        List<TimeTracking> _Employees = new List<TimeTracking>();

        public EmployeeController() {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        public TimeTracking getEmployeeID(string ID)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44368");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/TimeTracking/employee/" + ID).Result;
            if (response.IsSuccessStatusCode)
            {
                _Employee = response.Content.ReadAsAsync<TimeTracking>().Result;
            }
            return _Employee;
        }

        [HttpGet]
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44368");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/TimeTracking/employee").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<List<TimeTracking>>().Result;
            }
            else {
                ViewBag.Error = "Error";            
            }
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TimeTracking add)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44368/api/TimeTracking/add");
            var postJob = client.PostAsJsonAsync<TimeTracking>("add", add);
            postJob.Wait();

            var postResult = postJob.Result;
            if (postResult.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Error";
            }
            return View(add);
        }
        public ActionResult Edit(string ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            TimeTracking emp = getEmployeeID(ID);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(TimeTracking edit)
        {

            var responseBody = String.Empty;
            HttpClient client = new HttpClient();
            Uri apiUrl = new Uri("https://localhost:44368/api/TimeTracking/edit/" + edit.ID);
            var jsonRequest = JsonConvert.SerializeObject(edit);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");
            HttpResponseMessage response = client.PatchAsync(apiUrl, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Error";
            }
            return View(edit);
        }
        //[HttpGet]
        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    EmployeeInfo emp = employeeDAL.GetEmployeeById(id);
        //    if (emp == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(emp);
        //}
        public ActionResult Delete(string ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            TimeTracking emp = getEmployeeID(ID);
            emp.isActive.ToString();
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TimeTracking delete)
        {
            var responseBody = String.Empty;
            HttpClient client = new HttpClient();
            Uri apiUrl = new Uri("https://localhost:44368/api/TimeTracking/delete/" + delete.ID);
            var jsonRequest = JsonConvert.SerializeObject(delete);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");
            HttpResponseMessage response = client.DeleteAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Error";
            }

            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Login");
        }

    }
}