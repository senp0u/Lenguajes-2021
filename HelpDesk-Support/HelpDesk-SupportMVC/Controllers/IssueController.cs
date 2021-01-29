using HelpDesk_SupportMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HelpDesk_SupportMVC.Controllers
{
    public class IssueController : Controller
    {

        string apiBaseUrl;

        public IssueController(IConfiguration configuration)
        {
            apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> GetIssues()
        {
            IEnumerable<Issue> students = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/Issue"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<IEnumerable<Issue>>(apiResponse);
                }
            }
            return Json(students);
        }
    }
}
