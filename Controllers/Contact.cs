using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgramlama_Odev.Models;

namespace WebProgramlama_Odev.Controllers
{
    public class Contact : Controller
    {

        AirlineContext c = new AirlineContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            var mesaj = user.message;
            var _email = user.email;

            var kullanici = c.Users.FirstOrDefault(x => x.email == _email);

            
                if (kullanici != null)
                {
                    kullanici.message = mesaj;
                    c.SaveChanges();

                    ViewData["Mesaj"] = "Mesaj başarıyla güncellendi.";

                    return View();


                }
                else
                {
                    ViewData["Mesaj"] = "Kullanıcı bulunamadı. Lütfen kayıt olun.";
                    return View();
                }
                      
           
        }

      



    }
}
