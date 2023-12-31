using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Security.Claims;
using WebProgramlama_Odev.Models;


namespace WebProgramlama_Odev.Controllers
{
    
    public class AdminController : Controller
    {

         AirlineContext c = new AirlineContext();

      

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginAdmin()
        {
            return View();
        }
        public async Task<IActionResult> LoginAdmin(AdminModel adm)
        {

            var inf = c.Admins.FirstOrDefault(x => x.email.ToLower() == adm.email.ToLower() && x.Password == adm.Password);

            if (inf != null)
            {
                var claims = new List<Claim>() {

                    new Claim(ClaimTypes.Email,adm.email)


                };

                var userIdentity = new ClaimsIdentity(claims, "Admin");
                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(userPrincipal);
                return View("Settings");

            }
            return View();


        }

        public IActionResult Messages(AdminModel adm)
        {
            return View();

        }

        public IActionResult Ayarlar()
        {

            return View();
        }



        // GET: AdminModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || c.Admins == null)
            {
                return NotFound();
            }

            var adminModel = await c.Admins
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (adminModel == null)
            {
                return NotFound();
            }

            return View(adminModel);
        }

        // GET: AdminModels/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdmin,Name,email,Password")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                if (c.Admins.Any(x => x.email == adminModel.email))
                {
                    ModelState.AddModelError("email", "Bu e-posta adresi zaten kullanımda.");
                    return View(adminModel);
                }
                c.Add(adminModel);
                await c.SaveChangesAsync();
                return RedirectToAction("Index", "CallApi");

            }
            return View(adminModel);
        }

        // GET: AdminModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || c.Admins == null)
            {
                return NotFound();
            }

            var adminModel = await c.Admins.FindAsync(id);
            if (adminModel == null)
            {
                return NotFound();
            }
            return View(adminModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdmin,Name,email,Password")] AdminModel adminModel)
        {
            if (id != adminModel.IdAdmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    c.Update(adminModel);
                    await c.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminModelExists(adminModel.IdAdmin))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","CallApi");
            }
            return View(adminModel);
        }

        // GET: AdminModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || c.Admins == null)
            {
                return NotFound();
            }

            var adminModel = await c.Admins
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (adminModel == null)
            {
                return NotFound();
            }

            return View(adminModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (c.Admins == null)
            {
                return Problem("Entity set 'AirlineContext.Admins'  is null.");
            }
            var adminModel = await c.Admins.FindAsync(id);
            if (adminModel != null)
            {
                c.Admins.Remove(adminModel);
            }

            await c.SaveChangesAsync();
            return RedirectToAction("Index","CallApi");
          
        }

        private bool AdminModelExists(int id)
        {
            return (c.Admins?.Any(e => e.IdAdmin == id)).GetValueOrDefault();
        }

    }
}
