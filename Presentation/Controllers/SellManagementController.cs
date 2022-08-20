using AdminDashboard.Core.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class SellManagementController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var url = "http://localhost:62244/api/sellManagement";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<IEnumerable<SellManagementDTO>>>(res);

            return View(json);
        }
        public async Task<IActionResult> LoadData()
        {
            var url = "http://localhost:62244/api/sellManagement";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<IEnumerable<SellManagementDTO>>>(res);

            return Json(json.Data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SellManagementDTO sellManagement)
        {
            var json = JsonConvert.SerializeObject(sellManagement);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://localhost:62244/api/sellManagement";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Get(int id)
        {
            var url = $"http://localhost:62244/api/sellManagement/{id}";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<SellManagementDTO>>(res);

            return View(json);
        }
        public async Task<IActionResult> EditBook(int id)
        {
            var url = $"http://localhost:62244/api/sellManagement/Get/{id}";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<SellManagementDTO>>(res);

            return Json(json.Data);
        }
        [HttpPost]
        public async Task<IActionResult> EditBook(SellManagementDTO sellManagement, int id)
        {
            var json = JsonConvert.SerializeObject(sellManagement);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"http://localhost:62244/api/sellManagement/Edit/{sellManagement}";

            HttpClient client = new HttpClient();

            var response = await client.PutAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();

            return Json(result);
        }
        public async Task<IActionResult> DeleteBook(int id)
        {
            var url = $"http://localhost:62244/api/sellManagement/Delete/{id}";

            HttpClient client = new HttpClient();

            var res = await client.DeleteAsync(url);

            return RedirectToAction("index", res);
        }
    }
}
