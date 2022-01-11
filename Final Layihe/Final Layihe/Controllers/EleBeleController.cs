using Final_Layihe.DAL;
using Final_Layihe.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_layihe.controllers
{
    public class EleBeleController : Controller
    {
        private readonly AppDbContext _context;
        public EleBeleController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            EleBeleVM elebelevm = new EleBeleVM
            {
                Elebeles = await _context.Elebeles.ToListAsync()
            };

            return View(elebelevm);
        }

    }
}
