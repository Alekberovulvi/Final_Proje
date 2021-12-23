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
    public class PizzaController : Controller
    {
        private readonly AppDbContext _context;
        public PizzaController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            PizzaVM pizzaVM = new PizzaVM
            {
                Pizzas = await _context.Pizzas.ToListAsync()
            };
            return View(pizzaVM);
        }

        public async Task<IActionResult> GetDetails(int? Id)
        {
            if (Id == null)
                return NotFound();

            Pizza pizza = await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == Id);

            if (pizza == null)
                return NotFound();

            return PartialView("_PizzaDetailPartial", pizza);
        }
    }
}
