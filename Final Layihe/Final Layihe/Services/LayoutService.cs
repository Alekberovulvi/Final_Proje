using Final_Layihe.DAL;
using Final_Layihe.Models;
using Final_Layihe.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;

        public LayoutService(AppDbContext context, IHttpContextAccessor accessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _accessor = accessor;
            _userManager = userManager;
        }

        public async Task<List<BasketVM>> GetBasketItems()
        {
            List<BasketVM> productBaskets = new List<BasketVM>();
            AppUser user = _accessor.HttpContext.User.Identity.IsAuthenticated ? await _userManager.FindByNameAsync(_accessor.HttpContext.User.Identity.Name) : null;
            if (user == null)
            {
                if (_accessor.HttpContext.Request.Cookies["basket"] != null)
                {
                    productBaskets = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
                }
            }
            else
            {
                productBaskets = _context.BasketItems.Where(x => x.AppUserId == user.Id).Select(x => new BasketVM
                {
                    Title = x.Title,
                    Count = x.Count,
                    Image = x.Image,
                    ProductId = (int)x.SnackId,
                    Price = x.Price,
                }).ToList();
            }

            return productBaskets;
        }

    }
}
