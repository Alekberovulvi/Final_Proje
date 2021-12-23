using Final_Layihe.DAL;
using Final_Layihe.Models;
using Final_Layihe.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Controllers
{
    public class DesertController : Controller
    {
        private readonly AppDbContext _context;
        public DesertController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            DesertVM desertVM = new DesertVM
            {
                Deserts = await _context.Deserts.ToListAsync()
            };
            return View(desertVM);
        }

        public async Task<IActionResult> GetDetails(int? Id)
        {
            if (Id == null)
                return NotFound();

            Desert desert = await _context.Deserts.FirstOrDefaultAsync(d=>d.Id==Id);

            if (desert == null)
                return NotFound();

            return PartialView("_DesertDetailPartial", desert);
        }
    }
}
