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
    public class CampaignController : Controller
    {
        private readonly AppDbContext _context;
        public CampaignController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            CampaignVM campaignVM = new CampaignVM()
            {
                Campaign = await _context.Campaigns.ToListAsync()
            };

            return View(campaignVM);
        }
    }
}
