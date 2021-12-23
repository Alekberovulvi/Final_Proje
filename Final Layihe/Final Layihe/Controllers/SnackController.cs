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
    public class SnackController : Controller
    {
        private readonly AppDbContext _context;
        public SnackController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            SnackVM snackVM = new SnackVM
            {
                Snacks = await _context.Snacks.ToListAsync()
            };
            return View(snackVM);
        }

        public async Task<IActionResult> GetDetails(int? Id)
        {
            if (Id == null)
                return NotFound();

            Snack snack = await _context.Snacks.FirstOrDefaultAsync(s => s.Id == Id);

            if (snack == null)
                return NotFound();


            return PartialView("_SnackDetailPartial", snack);
        }
    }
}
