using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebProgramlama_Odev.Models;

namespace WebProgramlama_Odev.Controllers
{
    public class CallApiController : Controller
    {

        public async Task<IActionResult> Index()
        {
            List<AdminModel> adminler = new List<AdminModel>();
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("https://localhost:7147/api/AdminApi");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            adminler = JsonConvert.DeserializeObject<List<AdminModel>>(jsonResponse);

            return View(adminler);

        }



            
            
    }
}
