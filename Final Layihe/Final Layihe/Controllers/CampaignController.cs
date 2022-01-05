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

        public async Task<ActionResult> Detail(int? Id)
        {
            if (Id == null)
                return NotFound();
          
            Campaign campaign = new Campaign();
            campaign = await _context.Campaigns.FirstOrDefaultAsync(x=>x.Id==Id);
            if (campaign == null)
                return NotFound();
            return View(campaign);
        }

    }
}
