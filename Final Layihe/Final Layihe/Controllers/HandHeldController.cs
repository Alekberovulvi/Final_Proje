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
    public class HandHeldController : Controller
    {
        private readonly AppDbContext _context;
        public HandHeldController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            CampaignDetailVM campaignDetailVM = new CampaignDetailVM
            {
                HandHelds = await _context.HandHelds.ToListAsync()
            };
            return View(campaignDetailVM);
        }
    }
}
