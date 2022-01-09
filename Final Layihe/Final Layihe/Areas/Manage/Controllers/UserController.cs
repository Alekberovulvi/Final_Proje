using Final_Layihe.Models;
using Final_Layihe.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Areas.Manage.Controllers
{
    [Area("manage")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<AppUser> appUser = await _userManager.Users.ToListAsync();
            List<AccountVM> accountvm = new List<AccountVM>();

            foreach (AppUser appUser1 in appUser)
            {
                AccountVM accountVM = new AccountVM
                {
                    Id = appUser1.Id,
                    Name = appUser1.Name,
                    SurName = appUser1.SurName,
                    Phone = appUser1.Phone,
                    Email = appUser1.Email,
                    UserName = appUser1.UserName,
                    Role = (await _userManager.GetRolesAsync(appUser1))[0]
                };

                accountvm.Add(accountVM);
            }


            return View(accountvm);
        }
    }
}
