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
    public class ColdController : Controller
    {
        private readonly AppDbContext _context;
        public ColdController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            CampaignDetailVM campaignDetailVM = new CampaignDetailVM
            {
                Colds = await _context.Colds.ToListAsync()
            };
            return View(campaignDetailVM);
        }

    }
}
