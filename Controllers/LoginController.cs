using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebProgramlama_Odev.Models;

namespace WebProgramlama_Odev.Controllers
{
    public class LoginController : Controller
    {   

        AirlineContext c = new AirlineContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Index(User usr)
        {

            var inf = c.Users.FirstOrDefault(x => x.email.ToLower() == usr.email.ToLower() && x.password == usr.password);

            if (inf != null)
            {
                var claims = new List<Claim>() {

                    new Claim(ClaimTypes.Email,usr.email)


                };

                var userIdentity = new ClaimsIdentity(claims, "User");
                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(userPrincipal);
                return RedirectToAction("Index","Guzergah");

            }
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

           
            return RedirectToAction("Index", "Guzergah");
        }

        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KayitOl([Bind("UserId,firstname,lastname,email,phone,password")] User user)
        {
           

            if (ModelState.IsValid)
            {
                if (c.Admins.Any(x => x.email == user.email))
                {
                    ModelState.AddModelError("email", "Bu e-posta adresi zaten kullanımda.");
                    return View(user);
                }

                c.Add(user);
                await c.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


    }
}
