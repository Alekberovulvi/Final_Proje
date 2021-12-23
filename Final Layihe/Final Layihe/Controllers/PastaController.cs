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
    public class PastaController : Controller
    {
        private readonly AppDbContext _context;
        public PastaController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            PastaVM pastaVM = new PastaVM
            {
                Pastas = await _context.Pastas.ToListAsync()
            };
            return View(pastaVM);
        }

        public async Task<IActionResult> GetDetails(int? Id)
        {
            if (Id == null)
                return NotFound();

            Pasta pasta = await _context.Pastas.FirstOrDefaultAsync(p=>p.Id==Id);

            if (pasta == null)
                return NotFound();

            return PartialView("_PastaDetailPartial", pasta);
        }
    }
}
