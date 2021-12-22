using Final_Layihe.DAL;
using Final_Layihe.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Controllers
{
    public class BounceController : Controller
    {
        private readonly AppDbContext _context;
        public BounceController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            BounceVM bounceVM = new BounceVM()
            {
                Bounce = await _context.Bounces.FirstOrDefaultAsync(),
                BounceImg = await _context.BounceImgs.FirstOrDefaultAsync()
            };
            return View(bounceVM);
        }
    }
}
