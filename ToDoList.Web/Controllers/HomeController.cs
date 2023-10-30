using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using ToDoList.Web.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Web.DTO;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ToDoList.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        string baseURL = "http://178.128.23.9:5952/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page, int size, string? key)
        {
            var list = new listInfo();
            var sizeCount = 1;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/List?key=&order=&ascending=true&page=1size=10&statusList=1");
                HttpResponseMessage Resu = await client.GetAsync("api/List?key="+key+"&order=&ascending=true&page="+page+"&size="+size+"&statusList=1");

                if (size == 0)
                {
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        list = JsonConvert.DeserializeObject<listInfo>(EmpResponse);
                    }
                }
                else if(size != null || page != null || key != null)
                {
                    if (Resu.IsSuccessStatusCode)
                    {
                        var EmpResponse = Resu.Content.ReadAsStringAsync().Result;
                        list = JsonConvert.DeserializeObject<listInfo>(EmpResponse);
                        var listItem = JsonConvert.DeserializeObject<listInfo>(EmpResponse);
                        sizeCount =(list.data.Count() / size)+1;
                        ViewBag.CountData = sizeCount;
                    }
                }
                ViewBag.CountData = sizeCount;

                return View(list);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(DataDto dataDto)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.PostAsJsonAsync("api/List", dataDto);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> Edit( int id)
        {
            var list = new datas();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"http://178.128.23.9:5952/api/List/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //var option = new JsonSerializerOptions
                    //{
                    //    ReferenceHandler = ReferenceHandler.Preserve
                    //};
                    //var jsonString = JsonSerializer.Serialize(EmpResponse, option);
                    list = JsonConvert.DeserializeObject<datas>(EmpResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}