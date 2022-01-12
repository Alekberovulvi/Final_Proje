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
    public class PastaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PastaController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pastas.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pasta pasta)
        {

            if (!ModelState.IsValid)
                return View(pasta);

            if (!pasta.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Duzgun File Secin");
                return View(pasta);
            }

            if ((pasta.Photo.Length / 1024) > 200)
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                return View(pasta);
            }



            string path = _env.WebRootPath;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + pasta.Photo.FileName;
            pasta.Image = fileName;
            string filePath = Path.Combine(path, "images", fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await pasta.Photo.CopyToAsync(fileStream);
            }

            await _context.Pastas.AddAsync(pasta);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

            if (await _context.Campaigns.AnyAsync(c => c.Title.ToLower() == pasta.Title.ToLower()))
            {
                ModelState.AddModelError("Title", $"{pasta.Title} adda Pasta var");
                return View(pasta);
            }

            await _context.Pastas.AddAsync(pasta);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return View("Error404");

            Pasta pasta = await _context.Pastas.FirstOrDefaultAsync(c => c.Id == Id);

            if (pasta == null)
                return View("Error404");

            return View(pasta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, Pasta pasta)
        {
            if (!ModelState.IsValid)
            {
                return View(pasta);
            }

            if (Id == null)
                return View("Error404");

            Pasta existpasta = await _context.Pastas.FirstOrDefaultAsync(c => c.Id == Id);

            if (pasta == null)
                return View("Error404");

            if (pasta.Photo != null)
            {
                if (!pasta.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Photo", "Duzgun File Secin");
                    return View(pasta);
                }

                if ((pasta.Photo.Length / 1024) > 200)
                {
                    ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                    return View(pasta);
                }


                string path = _env.WebRootPath;

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + pasta.Photo.FileName;
                string filePath = Path.Combine(path, "images", fileName);
                string oldfilePath = Path.Combine(path, "images", existpasta.Image);

                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }

                existpasta.Image = fileName;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await existpasta.Photo.CopyToAsync(fileStream);
                }
            }

            existpasta.Title = pasta.Title;
            existpasta.Desc = pasta.Desc;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            Pasta pasta = await _context.Pastas.FindAsync(id);
            _context.Pastas.Remove(pasta);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
