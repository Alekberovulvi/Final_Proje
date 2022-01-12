using Final_Layihe.DAL;
using Final_Layihe.Models;
using Final_Layihe.ViewModels;
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
    public class SousController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SousController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sous.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sous sous)
        {

            if (!ModelState.IsValid)
                return View(sous);

            if (!sous.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Duzgun File Secin");
                return View(sous);
            }

            if ((sous.Photo.Length / 1024) > 200)
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                return View(sous);
            }



            string path = _env.WebRootPath;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + sous.Photo.FileName;
            sous.Image = fileName;
            string filePath = Path.Combine(path, "images", fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await sous.Photo.CopyToAsync(fileStream);
            }

            await _context.Sous.AddAsync(sous);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

            if (await _context.Campaigns.AnyAsync(c => c.Title.ToLower() == sous.Title.ToLower()))
            {
                ModelState.AddModelError("Title", $"{sous.Title} adda Pasta var");
                return View(sous);
            }

            await _context.Sous.AddAsync(sous);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return View("Error404");

            Sous sous = await _context.Sous.FirstOrDefaultAsync(c => c.Id == Id);

            if (sous == null)
                return View("Error404");

            return View(sous);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, Sous sous)
        {
            if (!ModelState.IsValid)
            {
                return View(sous);
            }

            if (Id == null)
                return View("Error404");

            Sous existsous = await _context.Sous.FirstOrDefaultAsync(c => c.Id == Id);

            if (sous == null)
                return View("Error404");

            if (sous.Photo != null)
            {
                if (!sous.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Photo", "Duzgun File Secin");
                    return View(sous);
                }

                if ((sous.Photo.Length / 1024) > 200)
                {
                    ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                    return View(sous);
                }


                string path = _env.WebRootPath;

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + sous.Photo.FileName;
                string filePath = Path.Combine(path, "images", fileName);
                string oldfilePath = Path.Combine(path, "images", existsous.Image);

                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }

                existsous.Image = fileName;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await existsous.Photo.CopyToAsync(fileStream);
                }
            }

            existsous.Title = sous.Title;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            Sous sous = await _context.Sous.FindAsync(id);
            _context.Sous.Remove(sous);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
