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
    public class DrinkController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DrinkController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drinks.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Drink drink)
        {

            if (!ModelState.IsValid)
                return View(drink);

            if (!drink.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Duzgun File Secin");
                return View(drink);
            }

            if ((drink.Photo.Length / 1024) > 200)
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                return View(drink);
            }



            string path = _env.WebRootPath;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + drink.Photo.FileName;
            drink.Image = fileName;
            string filePath = Path.Combine(path, "images", fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await drink.Photo.CopyToAsync(fileStream);
            }

            await _context.Drinks.AddAsync(drink);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

            if (await _context.Drinks.AnyAsync(c => c.Title.ToLower() == drink.Title.ToLower()))
            {
                ModelState.AddModelError("Title", $"{drink.Title} adda Pasta var");
                return View(drink);
            }

            await _context.Drinks.AddAsync(drink);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return View("Error404");

            Drink drink = await _context.Drinks.FirstOrDefaultAsync(c => c.Id == Id);

            if (drink == null)
                return View("Error404");

            return View(drink);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, Drink drink)
        {
            if (!ModelState.IsValid)
            {
                return View(drink);
            }

            if (Id == null)
                return View("Error404");

            Drink existdrink = await _context.Drinks.FirstOrDefaultAsync(c => c.Id == Id);

            if (drink == null)
                return View("Error404");

            if (drink.Photo != null)
            {
                if (!drink.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Photo", "Duzgun File Secin");
                    return View(drink);
                }

                if ((drink.Photo.Length / 1024) > 200)
                {
                    ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                    return View(drink);
                }


                string path = _env.WebRootPath;

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + drink.Photo.FileName;
                string filePath = Path.Combine(path, "images", fileName);
                string oldfilePath = Path.Combine(path, "images", existdrink.Image);

                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }

                existdrink.Image = fileName;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await existdrink.Photo.CopyToAsync(fileStream);
                }
            }

            existdrink.Title = drink.Title;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            Drink drink = await _context.Drinks.FindAsync(id);
            _context.Drinks.Remove(drink);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
