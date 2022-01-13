using Final_Layihe.DAL;
using Final_Layihe.Models;
using Final_Layihe.Services;
using Final_Layihe.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _usermanager;
        private readonly LayoutService _service;
        public CartController(AppDbContext context, UserManager<AppUser> usermanager, LayoutService service)
        {
            _context = context;
            _usermanager = usermanager;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<BasketVM> model = await _service.GetBasketItems();
            return View(model);
        }

        public async Task<IActionResult> RemoveFromBasket(int? id)
        {
            if (id == null) return NotFound();
            List<BasketVM> BasketItems = new List<BasketVM>();

            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;
            if (user == null)
            {
                string basketStr = HttpContext.Request.Cookies["basket"];
                BasketItems = JsonConvert.DeserializeObject<List<BasketVM>>(basketStr);
                BasketVM productBasket = BasketItems.FirstOrDefault(x => x.ProductId == id);
                if (productBasket == null) return NotFound();

                BasketItems.Remove(productBasket);

                HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(BasketItems));
            }
            else
            {
                BasketItem product = _context.BasketItems.FirstOrDefault(x => x.SnackId == id);
                _context.BasketItems.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
    }