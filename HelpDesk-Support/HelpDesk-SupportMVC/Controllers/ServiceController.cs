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
    public class ServiceController : Controller
    {
        private readonly string apiBaseUrl;

        public ServiceController(IConfiguration configuration)
        {
            apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            IEnumerable<Service> services = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/service"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    services = JsonConvert.DeserializeObject<IEnumerable<Service>>(apiResponse);
                }
            }
            return Json(services);
        }
    }
}