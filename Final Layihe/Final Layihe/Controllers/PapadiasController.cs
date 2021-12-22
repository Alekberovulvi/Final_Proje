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
    public class PapadiasController : Controller
    {
        private readonly AppDbContext _context;
        public PapadiasController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            PapadiasVM papadiasVM = new PapadiasVM()
            {
                Papadias = await _context.Papadias.ToListAsync()
            };
            return View(papadiasVM);
        }
        public async Task<IActionResult> GetDetails(int? Id)
        {
            if (Id == null)
                return NotFound();

            Papadias papadias = await _context.Papadias.FirstOrDefaultAsync(p=>p.Id==Id);

            if (papadias == null)
                return NotFound();

            return PartialView("_PapadiasDetailPatial", papadias);
        }

    }
}
