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
    public class SousController : Controller
    {
        private readonly AppDbContext _context;
        public SousController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            SousVM sousVM = new SousVM
            {
                Sous = await _context.Sous.ToListAsync()
            };

            return View(sousVM);
        }

        public async Task<IActionResult> GetDetails(int? Id)
        {
            if (Id == null)
                return NotFound();

            Sous sous = await _context.Sous.FirstOrDefaultAsync(s=>s.Id==Id);

            if (sous == null)
                return NotFound();

            return PartialView("_SousDetailPartial", sous);
        }
    }
}
