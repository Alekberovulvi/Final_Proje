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
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            CategoryVM categoryVM = new CategoryVM
            {
                Categories = await _context.Categories.ToListAsync(),
                Abouts = await _context.Abouts.Include(a=>a.Category).ToListAsync()
            };

                return View(categoryVM);
        }
    }
}
