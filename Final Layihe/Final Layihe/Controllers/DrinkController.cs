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
    public class DrinkController : Controller
    {
        private readonly AppDbContext _context;
        public DrinkController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            DrinkVM drinkVM = new DrinkVM
            {
                Drinks = await _context.Drinks.ToListAsync()
            };
            return View(drinkVM);
        }

        public async Task<IActionResult> GetDetails(int? Id)
        {
            if (Id == null)
                return NotFound();

            Drink drink = await _context.Drinks.FirstOrDefaultAsync(d=>d.Id==Id);

            if(drink == null)
            return NotFound();

            return PartialView("_DrinkDetailPartial", drink);
        }

    }
}
