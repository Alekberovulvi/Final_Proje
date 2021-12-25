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
    public class ClassicController : Controller
    {
        private readonly AppDbContext _context;
        public ClassicController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            CampaignDetailVM campaignDetailVM = new CampaignDetailVM
            {
                Classics = await _context.Classics.ToListAsync()
            };
            return View(campaignDetailVM);
        }

    }
}
