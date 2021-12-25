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
    public class BrithdayController : Controller
    {
        private readonly AppDbContext _context;
        public BrithdayController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            CampaignDetailVM campaignDetailVM = new CampaignDetailVM
            {
                Brithdays = await _context.Brithdays.ToListAsync()
            };
            return View(campaignDetailVM);
        }
    }
}
