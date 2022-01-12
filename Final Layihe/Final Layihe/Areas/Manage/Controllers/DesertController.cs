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
    public class DesertController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DesertController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deserts.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Desert desert)
        {

            if (!ModelState.IsValid)
                return View(desert);

            if (!desert.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Duzgun File Secin");
                return View(desert);
            }

            if ((desert.Photo.Length / 1024) > 200)
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                return View(desert);
            }



            string path = _env.WebRootPath;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + desert.Photo.FileName;
            desert.Image = fileName;
            string filePath = Path.Combine(path, "images", fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await desert.Photo.CopyToAsync(fileStream);
            }

            await _context.Deserts.AddAsync(desert);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

            if (await _context.Deserts.AnyAsync(c => c.Title.ToLower() == desert.Title.ToLower()))
            {
                ModelState.AddModelError("Title", $"{desert.Title} adda Pasta var");
                return View(desert);
            }

            await _context.Deserts.AddAsync(desert);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return View("Error404");

            Desert desert = await _context.Deserts.FirstOrDefaultAsync(c => c.Id == Id);

            if (desert == null)
                return View("Error404");

            return View(desert);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, Desert desert)
        {
            if (!ModelState.IsValid)
            {
                return View(desert);
            }

            if (Id == null)
                return View("Error404");

            Desert existdesert  = await _context.Deserts.FirstOrDefaultAsync(c => c.Id == Id);

            if (desert == null)
                return View("Error404");

            if (desert.Photo != null)
            {
                if (!desert.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Photo", "Duzgun File Secin");
                    return View(desert);
                }

                if ((desert.Photo.Length / 1024) > 200)
                {
                    ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                    return View(desert);
                }


                string path = _env.WebRootPath;

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + desert.Photo.FileName;
                string filePath = Path.Combine(path, "images", fileName);
                string oldfilePath = Path.Combine(path, "images", existdesert.Image);

                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }

                existdesert.Image = fileName;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await existdesert.Photo.CopyToAsync(fileStream);
                }
            }

            existdesert.Title = desert.Title;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            Desert desert = await _context.Deserts.FindAsync(id);
            _context.Deserts.Remove(desert);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
