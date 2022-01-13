using Final_Layihe.DAL;
using Final_Layihe.Models;
using Final_Layihe.Services;
using Final_Layihe.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly LayoutService _service;

        public CheckoutController(AppDbContext context,UserManager<AppUser> userManager,LayoutService service)
        {
            _context = context;
            _userManager = userManager;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            AppUser user = User.Identity.IsAuthenticated ? await _userManager.FindByNameAsync(User.Identity.Name) : null;
            OrderVM model = new OrderVM
            {
                BasketVMs = await _service.GetBasketItems(),
                Email = user==null?"":user.Email,
                Name = user==null?"":user.Name,
                Surname = user == null ? "" : user.SurName

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(OrderVM order)
        {
            List<BasketVM> products = await _service.GetBasketItems();
            AppUser user = User.Identity.IsAuthenticated ? await _userManager.FindByNameAsync(User.Identity.Name) : null;
            order.BasketVMs = products;
            if (!ModelState.IsValid) return View("Index",order);
            Order newOrder = new Order
            {
                Address = order.Address,
                AppUserId = user != null ? user.Id : null,
                Email = order.Email,
                Fullname = order.Name + " " + order.Surname,
                Phone = order.Phone,
                Date = DateTime.UtcNow.AddHours(4)
            };
            newOrder.OrderItems = new List<OrderItem>();
            double totalPrice = 0;
            foreach (BasketVM product in products)
            {
                totalPrice += product.Price * product.Count;
                newOrder.OrderItems.Add(new OrderItem
                {
                    Count = product.Count,
                    SnackId = product.ProductId,
                    ProductName = product.Title,
                    ProductPrice = product.Price,
                    
                });
                newOrder.TotalPrice = totalPrice;
            }
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            if (user == null)
            {
                HttpContext.Response.Cookies.Delete("basket");
            }
            else
            {
                _context.BasketItems.RemoveRange(_context.BasketItems.Where(x => x.AppUserId == user.Id));
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
