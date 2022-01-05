using Final_Layihe.DAL;
using Final_Layihe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CampaignController : Controller
    {
        private readonly AppDbContext _context;
        public CampaignController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campaigns.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null)
                return View("Error404");

            Campaign campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == Id);

            if (campaign == null)
                return View("Error404");

            return View(campaign);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Campaign campaign)
        {
            if (!ModelState.IsValid)
                return View(campaign);


            if(await _context.Campaigns.AnyAsync(c => c.Title.ToLower() == campaign.Title.ToLower()))
            {
                ModelState.AddModelError("Title", $"{campaign.Title} adda Kampaniya var");
                return View(campaign);
            }

            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return View("Error404");

            Campaign campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == Id);

            if (campaign == null)
                return View("Error404");

            return View(campaign);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, Campaign campaign)
        {
            if (!ModelState.IsValid)
            {
                return View(campaign);
            }

            if (Id == null)
                return View("Error404");

            Campaign existcampaign = await _context.Campaigns.FirstOrDefaultAsync(c=>c.Id==Id);

            if(campaign == null)
               return View("Error404");

            existcampaign.Title = campaign.Title;
            existcampaign.SubTitle = campaign.SubTitle;
            existcampaign.Desc = campaign.Desc;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            Campaign campaign = await _context.Campaigns.FindAsync(id);
            _context.Campaigns.Remove(campaign);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
