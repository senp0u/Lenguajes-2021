using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HelpDesk_SupportMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

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
            HttpContext.Session.SetString("name", "");
            HttpContext.Session.SetInt32("isSupervisor", 0);
            HttpContext.Session.SetString("firstSurname", "");
            HttpContext.Session.SetString("secondSurname", "");
            HttpContext.Session.SetString("error", "");
            return View();
        }

        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            dynamic redirect;
            if (employee.Email == null || employee.Password == null)
            {
                
                HttpContext.Session.SetString("error", "");
                redirect = View();
            }
            else { 

                Employee authorizedEmployee = GetEmployeeToAuthenticate(employee.Email, employee.Password);
                var isSupervisor = 0;
           
                if (authorizedEmployee != null)
                {
                    if (authorizedEmployee.IsSupervisor)
                    {
                        isSupervisor = 1;
                    }
                    else {
                        isSupervisor = 0;
                    }

                    HttpContext.Session.SetString("name", authorizedEmployee.Name);
                    HttpContext.Session.SetString("firstSurname", authorizedEmployee.FirstSurname);
                    HttpContext.Session.SetString("secondSurname", authorizedEmployee.SecondSurname);
                    HttpContext.Session.SetInt32("isSupervisor", isSupervisor);
                    HttpContext.Session.SetString("error", "");
                    redirect = RedirectToAction("Index", "Home", new {@approved = 1});
                }
                else
                {
                    ModelState.Clear();
                    HttpContext.Session.SetString("error", "Usuario o contraseña incorrecta.");
                    redirect = View();
                }
            }

            return redirect;

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

        ///Employee/GetNonSupervisors
        [HttpGet]
        public async Task<IActionResult> GetNonSupervisors()
        {
            IEnumerable<Employee> employees = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/Employee/GetEmployeesNonSupervisor"))
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

        public Employee GetEmployeeToAuthenticate(string email, string password)
        {

            Employee employee = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl + "/Employee/GetEmployeeToAuthenticate/email=" + email + "&password=" + password);
                try
                {
                    var responseTask = client.GetAsync(client.BaseAddress);
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Employee>();
                        readTask.Wait();
                        employee = readTask.Result;

                    }
                }
                catch (AggregateException)
                {
                    employee = null;
                }

                return employee ;
            }

        }
    }
}
