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
    public class SalatController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SalatController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salats.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Salat salat)
        {

            if (!ModelState.IsValid)
                return View(salat);

            if (!salat.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Duzgun File Secin");
                return View(salat);
            }

            if ((salat.Photo.Length / 1024) > 200)
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                return View(salat);
            }



            string path = _env.WebRootPath;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + salat.Photo.FileName;
            salat.Image = fileName;
            string filePath = Path.Combine(path, "images", fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await salat.Photo.CopyToAsync(fileStream);
            }

            await _context.Salats.AddAsync(salat);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

            if (await _context.Salats.AnyAsync(c => c.Title.ToLower() == salat.Title.ToLower()))
            {
                ModelState.AddModelError("Title", $"{salat.Title} adda Pasta var");
                return View(salat);
            }

            await _context.Salats.AddAsync(salat);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return View("Error404");

            Salat salat = await _context.Salats.FirstOrDefaultAsync(c => c.Id == Id);

            if (salat == null)
                return View("Error404");

            return View(salat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, Salat salat)
        {
            if (!ModelState.IsValid)
            {
                return View(salat);
            }

            if (Id == null)
                return View("Error404");

            Salat existsalat = await _context.Salats.FirstOrDefaultAsync(c => c.Id == Id);

            if (salat == null)
                return View("Error404");

            if (salat.Photo != null)
            {
                if (!salat.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Photo", "Duzgun File Secin");
                    return View(salat);
                }

                if ((salat.Photo.Length / 1024) > 200)
                {
                    ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                    return View(salat);
                }


                string path = _env.WebRootPath;

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + salat.Photo.FileName;
                string filePath = Path.Combine(path, "images", fileName);
                string oldfilePath = Path.Combine(path, "images", existsalat.Image);

                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }

                existsalat.Image = fileName;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await existsalat.Photo.CopyToAsync(fileStream);
                }
            }

            existsalat.Title = salat.Title;
            existsalat.Desc = salat.Desc;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            Salat salat = await _context.Salats.FindAsync(id);
            _context.Salats.Remove(salat);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
