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
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _usermanager;
        public CartController(AppDbContext context,UserManager<AppUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        public async Task<IActionResult> AddToCart(int? id, int? count)
        {
            if (id == null) return NotFound();
            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;
            Snack snack =  _context.Snacks.FirstOrDefault(x=>x.Id==id);
            List<BasketVM> basketProducts = new List<BasketVM>();
            if (user == null)
            {
                string basketStr = HttpContext.Request.Cookies["basket"];
                if (basketStr == null)
                {
                    basketProducts.Add(new BasketVM
                    {
                        ProductId = snack.Id,
                        Count = (int)count,
                        Title = snack.Title,
                        Price = (double)snack.Price,
                        Image = snack.Image
                    });
                }
                else
                {
                    basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(basketStr);
                    BasketVM productBasket = basketProducts.FirstOrDefault(x => x.ProductId == snack.Id);
                    if (productBasket != null)
                    {
                        productBasket.Count++;
                    }
                    else
                    {
                        basketProducts.Add(new BasketVM
                        {
                            ProductId = snack.Id,
                            Count = (int)count,
                            Title = snack.Title,
                            Price = (double)snack.Price,
                            Image = snack.Image
                        });
                    }
                }
                HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketProducts));
            }
            else
            {
                BasketItem productBasket = _context.BasketItems.Where(x => x.AppUserId == user.Id).FirstOrDefault(x => x.SnackId == id);
                if (productBasket == null)
                {
                    _context.BasketItems.Add(new BasketItem
                    {
                        SnackId = snack.Id,
                        Count = (int)count,
                        Title = snack.Title,
                        Price = (double)snack.Price,
                        Image = snack.Image,
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
    