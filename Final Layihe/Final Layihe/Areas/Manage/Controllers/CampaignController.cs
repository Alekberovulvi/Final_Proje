using Final_Layihe.DAL;
using Final_Layihe.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CampaignController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CampaignController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campaigns.ToListAsync());
        }
        [HttpGet]
       

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

            if (!campaign.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("File", "Duzgun File Secin");
                return View(campaign);
            }

            if ((campaign.Photo.Length / 1024) > 100)
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 100 kb ola bilər");
                return View(campaign);
            }

            campaign.ImageName = campaign.Photo.FileName;


            string path = _env.WebRootPath;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + campaign.Photo.FileName;
            campaign.Image = fileName;
            string filePath = Path.Combine(path, "images", fileName);

            using (FileStream fileStream=new FileStream(filePath, FileMode.Create))
            {
                await campaign.Photo.CopyToAsync(fileStream);
            }

            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

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


            if (campaign.Photo != null)
            {
                if (!campaign.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("File", "Duzgun File Secin");
                    return View(campaign);
                }

                if ((campaign.Photo.Length / 1024) > 100)
                {
                    ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 100 kb ola bilər");
                    return View(campaign);
                }

                existcampaign.ImageName = campaign.Photo.FileName;


                string path = _env.WebRootPath;

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + campaign.Photo.FileName;
                string filePath = Path.Combine(path, "images", fileName);
                string oldfilePath = Path.Combine(path, "images", existcampaign.Image);

                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }
                campaign.Image = fileName;



                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await campaign.Photo.CopyToAsync(fileStream);
                }
            }

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
