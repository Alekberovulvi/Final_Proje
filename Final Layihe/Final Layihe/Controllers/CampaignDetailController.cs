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
    public class CampaignDetailController : Controller
    {
        private readonly AppDbContext _context;
        public CampaignDetailController(AppDbContext context)
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

        public async Task<IActionResult> HandHeld()
        {
            CampaignDetailVM campaignDetailVM = new CampaignDetailVM
            {
                HandHelds = await _context.HandHelds.ToListAsync()
            };
            return View(campaignDetailVM);
        }

        public async Task<IActionResult> Cold()
        {
            CampaignDetailVM campaignDetailVM = new CampaignDetailVM
            {
                Colds = await _context.Colds.ToListAsync()
            };
            return View(campaignDetailVM);
        }

        public async Task<IActionResult> Party()
        {
            CampaignDetailVM campaignDetailVM = new CampaignDetailVM
            {
                Parties = await _context.Parties.ToListAsync()
            };

            return View(campaignDetailVM);
        }

        public async Task<IActionResult> Classic()
        {
            CampaignDetailVM campaignDetailVM = new CampaignDetailVM
            {
                Classics = await _context.Classics.ToListAsync()
            };

            return View(campaignDetailVM);
        }
    }
}
