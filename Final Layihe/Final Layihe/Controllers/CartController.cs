//using Final_Layihe.DAL;
//using Final_Layihe.Models;
//using Final_Layihe.ViewModels.Basket;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Final_Layihe.Controllers
//{
//    public class CartController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly UserManager<AppUser> _usermanager;

//        public CartController(AppDbContext context, UserManager<AppUser> usermanager)
//        {
//            _context = context;
//            _usermanager = usermanager;
//        }
//        public async Task<IActionResult> Index()
//        {
//            List<BasketVM> basketProducts = new List<BasketVM>();
//            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;

//            if (HttpContext.Request.Cookies["basket"] != null)
//            {
//                basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(HttpContext.Request.Cookies["basket"]);
//            }


//            return View(basketProducts);
//        }
//        public async Task<IActionResult> AddToCart(int? Id, int count)
//        {
//            if (Id == null) return NotFound();
//            Product product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == Id);
//            if (product == null) return NotFound();
//            AppUser user = User.Identity.IsAuthenticated ? await _usermanager.FindByNameAsync(User.Identity.Name) : null;
//            List<BasketVM> productBaskets = new List<BasketVM>();
//            string basket = HttpContext.Request.Cookies["Basket"];

//            #region AddCookie
//            if (basket == null)
//            {
//                productBaskets.Add(new BasketVM
//                {
//                    ProductId = product.Id,
//                    Count = count,
//                    Description = product.Description,
//                    Name = product.Name,
//                    Image = product.Image,
//                    Price = (decimal)product.Price
//                });
//            }
//            else
//            {
//                productBaskets = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
//                BasketVM productBasket = productBaskets.FirstOrDefault(x => x.ProductId == (int)Id);
//                if (productBasket == null)
//                {
//                    productBaskets.Add(new BasketVM
//                    {
//                        ProductId = product.Id,
//                        Count = count,
//                        Description = product.Description,
//                        Image = product.Image,
//                        Name = product.Name,
//                        Price = (decimal)product.Price
//                    });
//                }
//                else
//                {
//                    productBasket.Count += count;
//                }

//            }
//            HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productBaskets));



//            return RedirectToAction(nameof(Index), "Home");
//        }

//        public async Task<IActionResult> PlaceOrder()
//        {
//            string basket = HttpContext.Request.Cookies["Basket"];
//            var productBaskets = JsonConvert.DeserializeObject<List<BasketVM>>(basket);


//            if (!User.Identity.IsAuthenticated)
//                return RedirectToAction("Login", "Account");

//            var user = await _usermanager.FindByNameAsync(User.Identity.Name);
//            if (user is null)
//                return BadRequest();

//            foreach (var product in productBaskets)
//            {
//                _context.Orders.Add(new Order
//                {
//                    ProductId = product.ProductId,
//                    Count = product.Count,
//                    Description = product.Description,
//                    Name = product.Name,
//                    Phone = product.Phone,
//                    Image = product.Image,
//                    Total = (decimal)product.Price * product.Count,
//                    AppUserId = user.Id
//                });
//            }

//            await _context.SaveChangesAsync();
 
//            Response.Cookies.Delete("Basket");

//            return RedirectToAction("Index", "Home");
//        }
//        [HttpPost]
//        public IActionResult EmptyCart()
//        {
//            Response.Cookies.Delete("Basket");

//            return RedirectToAction("Index", "Cart");

//        }

//        public IActionResult RemoveFromCart(int? Id)
//        {
//            if (Id == null) return NotFound();
//            List<BasketVM> productBaskets = new List<BasketVM>();


//            string basketStr = HttpContext.Request.Cookies["Basket"];
//            productBaskets = JsonConvert.DeserializeObject<List<BasketVM>>(basketStr);
//            BasketVM productBasket = productBaskets.FirstOrDefault(x => x.ProductId == Id);
//            if (productBasket == null) return NotFound();

//            if (productBasket.Count == 1 || productBasket.Count <= 0)
//            {
//                productBaskets.Remove(productBasket);
//            }
//            else
//            {
//                productBasket.Count--;
//            }


//            HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productBaskets));

//            return RedirectToAction(nameof(Index));
//        }
    