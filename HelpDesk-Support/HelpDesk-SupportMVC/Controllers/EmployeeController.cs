using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HelpDesk_SupportMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HelpDesk_SupportMVC.Controllers
{
    public class EmployeeController : Controller
    {
        
        private readonly string apiBaseUrl;

        public EmployeeController(IConfiguration configuration)
        {

            apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            IEnumerable<Employee> employees = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/employee"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(apiResponse);
                }
            }
            return Json(employees);
        }


        ///Employee/GetSupervisor
        [HttpGet]
        public async Task<IActionResult> GetSupervisor()
        {
            IEnumerable<Employee> employees = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/Employee/GetEmployeeSupervisor"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(apiResponse);
                }
            }
            return Json(employees);
        }

        [HttpPost]
        public IActionResult PostEmployee([FromBody] Employee employee)
        {
            using (var httpClient = new HttpClient())
            {

                var postTask = httpClient.PostAsJsonAsync<Employee>(apiBaseUrl + "/employee", employee);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Employee>();
                    readTask.Wait();
                    employee = readTask.Result;
                }
            }
            return Ok(employee);
        }
    }
}