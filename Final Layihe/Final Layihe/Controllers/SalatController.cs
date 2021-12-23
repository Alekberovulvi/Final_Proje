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
    public class SalatController : Controller
    {
        private readonly AppDbContext _context;
        public SalatController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            SalatVM salatVM = new SalatVM
            {
                Salats = await _context.Salats.ToListAsync()
            };
            return View(salatVM);
        }

        public async Task<IActionResult> GetDetails(int? Id)
        {
            if (Id == null)
                return NotFound();

            Salat salat = await _context.Salats.FirstOrDefaultAsync(s=>s.Id==Id);

            if(salat == null)
            return NotFound();

            return PartialView("_SalatDetailPartial", salat);
        }
    }
}
