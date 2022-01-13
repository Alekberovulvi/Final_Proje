using Final_Layihe.DAL;
using Final_Layihe.Models;
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
    public class DrinkController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _usermanager;

        public DrinkController(AppDbContext context, UserManager<AppUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;

        }
        public async Task<IActionResult> Index()
        {
            DrinkVM drinkVM = new DrinkVM
            {
                Drinks = await _context.Drinks.ToListAsync()
            };
            return View(drinkVM);
        }

        public async Task<IActionResult> GetDetails(int? Id)
        {
            if (Id == null)
                return NotFound();

            Drink drink = await _context.Drinks.FirstOrDefaultAsync(d=>d.Id==Id);

            if(drink == null)
            return NotFound();

            return PartialView("_DrinkDetailPartial", drink);
        }


        public async Task<IActionResult> AddToCart(int? id, int? count)
        {
            if (id == null) return NotFound();
            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;
            Drink drink = _context.Drinks.FirstOrDefault(x => x.Id == id);
            List<BasketVM> basketProducts = new List<BasketVM>();
            if (user == null)
            {
                string basketStr = HttpContext.Request.Cookies["basket"];
                if (basketStr == null)
                {
                    basketProducts.Add(new BasketVM
                    {
                        ProductId = drink.Id,
                        Count = (int)count,
                        Title = drink.Title,
                        Price = (double)drink.Price,
                        Image = drink.Image
                    });
                }
                else
                {
                    basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(basketStr);
                    BasketVM productBasket = basketProducts.FirstOrDefault(x => x.ProductId == drink.Id);
                    if (productBasket != null)
                    {
                        productBasket.Count++;
                    }
                    else
                    {
                        basketProducts.Add(new BasketVM
                        {
                            ProductId = drink.Id,
                            Count = (int)count,
                            Title = drink.Title,
                            Price = (double)drink.Price,
                            Image = drink.Image
                        });
                    }
                }
                HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketProducts));
            }
            else
            {
                BasketItem productBasket = _context.BasketItems.Where(x => x.AppUserId == user.Id).FirstOrDefault(x => x.DrinkId == id);
                if (productBasket == null)
                {
                    _context.BasketItems.Add(new BasketItem
                    {
                        DrinkId = drink.Id,
                        Count = (int)count,
                        Title = drink.Title,
                        Price = (double)drink.Price,
                        Image = drink.Image,
                        AppUserId = user.Id
                    });
                }
                else
                {
                    productBasket.Count++;
                }
                _context.SaveChanges();
                basketProducts = _context.BasketItems.Where(x => x.AppUserId == user.Id).Select(x => new BasketVM
                {
                    Count = x.Count,
                    Image = x.Image,
                    ProductId = x.SnackId,
                    Price = x.Price,
                    Title = x.Title
                }).ToList();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
