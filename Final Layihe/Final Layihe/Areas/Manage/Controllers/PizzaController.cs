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
    public class PizzaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PizzaController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pizzas.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pizza pizza)
        {

            if (!ModelState.IsValid)
                return View(pizza);

            if (!pizza.Photo.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Photo", "Duzgun File Secin");
                return View(pizza);
            }

            if ((pizza.Photo.Length / 1024) > 200)
            {
                ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                return View(pizza);
            }



            string path = _env.WebRootPath;

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + pizza.Photo.FileName;
            pizza.Image = fileName;
            string filePath = Path.Combine(path, "images", fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await pizza.Photo.CopyToAsync(fileStream);
            }

            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

            if (await _context.Pizzas.AnyAsync(c => c.Title.ToLower() == pizza.Title.ToLower()))
            {
                ModelState.AddModelError("Title", $"{pizza.Title} adda Pasta var");
                return View(pizza);
            }

            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return View("Error404");

            Pizza pizza = await _context.Pizzas.FirstOrDefaultAsync(c => c.Id == Id);

            if (pizza == null)
                return View("Error404");

            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? Id, Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }

            if (Id == null)
                return View("Error404");

            Pizza existpizza = await _context.Pizzas.FirstOrDefaultAsync(c => c.Id == Id);

            if (pizza == null)
                return View("Error404");

            if (pizza.Photo != null)
            {
                if (!pizza.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Photo", "Duzgun File Secin");
                    return View(pizza);
                }

                if ((pizza.Photo.Length / 1024) > 200)
                {
                    ModelState.AddModelError("Photo", "Şəkilin ölçüsü maksimum 200 kb ola bilər");
                    return View(pizza);
                }


                string path = _env.WebRootPath;

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + pizza.Photo.FileName;
                string filePath = Path.Combine(path, "images", fileName);
                string oldfilePath = Path.Combine(path, "images", existpizza.Image);

                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }

                existpizza.Image = fileName;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await existpizza.Photo.CopyToAsync(fileStream);
                }
            }

            existpizza.Title = pizza.Title;
            existpizza.Desc = pizza.Desc;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            Pizza pizza = await _context.Pizzas.FindAsync(id);
            _context.Pizzas.Remove(pizza);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
