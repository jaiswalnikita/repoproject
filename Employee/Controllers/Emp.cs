using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Employee.Controllers
{
    public class Emp : Controller
    { 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
                List<EmpModel> emp = new List<EmpModel>();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7258/");
                HttpResponseMessage res = await client.GetAsync("api/EmpAPI/Index");
                if (res.IsSuccessStatusCode)
                {
                    var Result = res.Content.ReadAsStringAsync().Result;
                    emp = JsonConvert.DeserializeObject<List<EmpModel>>(Result);
                }

                return View(emp);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmpModel emp)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7258/");
            var res1 = client.PostAsJsonAsync<EmpModel>("api/EmpAPI/Create", emp);
            res1.Wait();
            var res = res1.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var emp = new EmpModel();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7258/");
            HttpResponseMessage res = await client.GetAsync($"api/EmpApi/Edit/{Id}");

            if (res.IsSuccessStatusCode)
            {
                var Result = res.Content.ReadAsStringAsync().Result;
                emp = JsonConvert.DeserializeObject<EmpModel>(Result);
            }

            return View(emp);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var emp = new EmpModel();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7258/");
            HttpResponseMessage res = await client.DeleteAsync($"api/EmpApi/Delete/{Id}");
            return RedirectToAction("Index");
            
        }

    }
}
