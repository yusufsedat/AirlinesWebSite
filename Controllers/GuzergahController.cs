
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using System.Security.Claims;
using WebProgramlama_Odev.Models;


namespace WebProgramlama_Odev.Controllers
{
    public class GuzergahController : Controller
    {

        AirlineContext c = new AirlineContext();


        public IActionResult Index()
        {
            List<String> nereden = c.Guzergah.Select(u => u.Nereden).Distinct().ToList();

            List<String> nereye = c.Guzergah.Select(u => u.Nereye).Distinct().ToList();

            ViewBag.NeredenList = nereden;
            ViewBag.NereyeList = nereye;

            return View();
        }

        [HttpPost]
        public IActionResult UygunUcusListesi(string selectedNereden, string selectedNereye)
        {

            var uygunUcuslar = c.Guzergah
                .Where(u => u.Nereden == selectedNereden && u.Nereye == selectedNereye)
                .ToList();


            return View("UygunUcusListesi", uygunUcuslar);
        }

        [HttpGet]     
        public IActionResult Choose(int id)
        {


            int ucusId = id;

            GuzergahModel guzergah = c.Guzergah
           .Include(g => g.Ucuss)
           .SingleOrDefault(g => g.UcusId == ucusId);

            UcusModel ilgiliUcus = guzergah.Ucuss?.FirstOrDefault();

            int pnrNo = ilgiliUcus.PnrNo;

            return View("BiletOlustur",pnrNo);

        }
        






    }







}

