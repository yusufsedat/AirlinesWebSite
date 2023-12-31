using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgramlama_Odev.Models;

namespace WebProgramlama_Odev.Controllers
{
    public class AdminGuzergahController : Controller
    {
        AirlineContext _context = new AirlineContext();

        // GET: AdminGuzergah
        public async Task<IActionResult> Index()
        {
              return _context.Guzergah != null ? 
                          View(await _context.Guzergah.ToListAsync()) :
                          Problem("Entity set 'AirlineContext.Guzergah'  is null.");
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Guzergah == null)
            {
                return NotFound();
            }

            var guzergahModel = await _context.Guzergah
                .FirstOrDefaultAsync(m => m.UcusId == id);
            if (guzergahModel == null)
            {
                return NotFound();
            }

            return View(guzergahModel);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UcusId,Nereden,Nereye,Tarih")] GuzergahModel guzergahModel)
        {
            if (ModelState.IsValid)
            {   
                var ucusModel= new UcusModel()
                {
                    Guzergah = guzergahModel

                };
                guzergahModel.Ucuss = new List<UcusModel> { ucusModel };
                _context.Add(guzergahModel);              
                await _context.SaveChangesAsync();                       
                return RedirectToAction(nameof(Index));
            }          
           
            return View(guzergahModel);
        }

      

        // GET: AdminGuzergah/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Guzergah == null)
            {
                return NotFound();
            }

            var guzergahModel = await _context.Guzergah.FindAsync(id);
            if (guzergahModel == null)
            {
                return NotFound();
            }
            return View(guzergahModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UcusId,Nereden,Nereye,Tarih")] GuzergahModel guzergahModel)
        {
            if (id != guzergahModel.UcusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guzergahModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuzergahModelExists(guzergahModel.UcusId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(guzergahModel);
        }

        // GET: AdminGuzergah/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Guzergah == null)
            {
                return NotFound();
            }

            var guzergahModel = await _context.Guzergah
                .FirstOrDefaultAsync(m => m.UcusId == id);
            if (guzergahModel == null)
            {
                return NotFound();
            }

            return View(guzergahModel);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Guzergah == null)
            {
                return Problem("Entity set 'AirlineContext.Guzergah'  is null.");
            }
            var guzergahModel = await _context.Guzergah.FindAsync(id);
            if (guzergahModel != null)
            {
                _context.Guzergah.Remove(guzergahModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuzergahModelExists(int id)
        {
          return (_context.Guzergah?.Any(e => e.UcusId == id)).GetValueOrDefault();
        }
    }
}
