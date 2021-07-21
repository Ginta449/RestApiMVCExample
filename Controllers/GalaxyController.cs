using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCRestApi.Models;
using Newtonsoft.Json;

namespace MVCRestApi.Controllers
{
    public class GalaxyController : Controller
    {
        string server = "https://localhost:44369/";

        public async Task<IActionResult> Index()
        {
            List<Galaxies> galaxyInfo = new List<Galaxies>();

            using (var client = new HttpClient())
            {
               
                client.BaseAddress = new Uri(server);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("GalaxyApi/GalaxyApi.json");
             
                if (Res.IsSuccessStatusCode)
                {
                  
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                   
                    galaxyInfo = JsonConvert.DeserializeObject<List<Galaxies>>(EmpResponse);
                }
            
                return View(galaxyInfo);
            }
        }
    }
}
