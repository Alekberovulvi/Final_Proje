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
    public class SnackController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SnackController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Snacks.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Snack snack)
        {

            if (!ModelState.IsValid)
                return View(snack);

            if (!snack.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Duzgun File Secin");
                return View(snack);
            }

            if ((snack.Photo.Length / 1024) > 200)
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                return View(snack);
            }



            string path = _env.WebRootPath;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + snack.Photo.FileName;
            snack.Image = fileName;
            string filePath = Path.Combine(path, "images", fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await snack.Photo.CopyToAsync(fileStream);
            }

            await _context.Snacks.AddAsync(snack);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

            if (await _context.Snacks.AnyAsync(c => c.Title.ToLower() == snack.Title.ToLower()))
            {
                ModelState.AddModelError("Title", $"{snack.Title} adda Pasta var");
                return View(snack);
            }

            await _context.Snacks.AddAsync(snack);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return View("Error404");

            Snack snack = await _context.Snacks.FirstOrDefaultAsync(c => c.Id == Id);

            if (snack == null)
                return View("Error404");

            return View(snack);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, Snack snack)
        {
            if (!ModelState.IsValid)
            {
                return View(snack);
            }

            if (Id == null)
                return View("Error404");

            Snack existsnack = await _context.Snacks.FirstOrDefaultAsync(c => c.Id == Id);

            if (snack == null)
                return View("Error404");

            if (snack.Photo != null)
            {
                if (!snack.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Photo", "Duzgun File Secin");
                    return View(snack);
                }

                if ((snack.Photo.Length / 1024) > 200)
                {
                    ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                    return View(snack);
                }


                string path = _env.WebRootPath;

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + snack.Photo.FileName;
                string filePath = Path.Combine(path, "images", fileName);
                string oldfilePath = Path.Combine(path, "images", existsnack.Image);

                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }

                existsnack.Image = fileName;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await existsnack.Photo.CopyToAsync(fileStream);
                }
            }

            existsnack.Title = snack.Title;
            existsnack.Desc = snack.Desc;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            Snack snack = await _context.Snacks.FindAsync(id);
            _context.Snacks.Remove(snack);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
