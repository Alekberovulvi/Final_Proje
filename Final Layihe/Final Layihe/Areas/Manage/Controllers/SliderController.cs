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
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {

            if (!ModelState.IsValid)
                return View(slider);

            if (!slider.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Duzgun File Secin");
                return View(slider);
            }

            if ((slider.Photo.Length / 1024) > 300)
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 300 kb ola bilər");
                return View(slider);
            }

            slider.ImageName = slider.Photo.FileName;


            string path = _env.WebRootPath;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + slider.Photo.FileName;
            slider.Image = fileName;
            string filePath = Path.Combine(path, "images", fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(fileStream);
            }

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return View("Error404");

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == Id);

            if (slider == null)
                return View("Error404");

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            if (Id == null)
                return View("Error404");

            Slider existslider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == Id);

            if (slider == null)
                return View("Error404");

            if (slider.Photo != null)
            {
                if (!slider.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Photo", "Duzgun File Secin");
                    return View(slider);
                }

                if ((slider.Photo.Length / 1024) > 200)
                {
                    ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                    return View(slider);
                }

                existslider.ImageName = slider.Photo.FileName;

                string path = _env.WebRootPath;

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + slider.Photo.FileName;
                string filePath = Path.Combine(path, "images", fileName);
                string oldfilePath = Path.Combine(path, "images", existslider.Image);

                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }

                existslider.Image = fileName;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await slider.Photo.CopyToAsync(fileStream);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
