using Final_Layihe.Models;
using Final_Layihe.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _manager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AccountController(UserManager<AppUser> manager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _manager = manager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return NotFound();

            AppUser appUser = await _manager.FindByEmailAsync(loginVM.Email);

            if(appUser==null)
            {
                ModelState.AddModelError("", "Email Və Ya Şifrə Yanlışdır");
                return View (loginVM);
            } 

           Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, true, true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Emailiniz bloklanib");
                return View(loginVM);
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email Və Ya Şifrə Yanlışdır");
                return View(loginVM);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            AppUser appUser = new AppUser
            {
                Name = register.Name,
                SurName = register.SurName,
                Phone = register.Phone,
                Email = register.Email,
                UserName = register.UserName
            };

            IdentityResult identityResult = await _manager.CreateAsync(appUser, register.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
                return View(register);
            }

            await _manager.AddToRoleAsync(appUser, "Member");

            await _signInManager.SignInAsync(appUser, false);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        #region Role
        //public async Task<IActionResult> Addrole()
        //{
        //    if (!await _roleManager.RoleExistsAsync("Admin"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    }
        //    if (!await _roleManager.RoleExistsAsync("Member"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
        //    }
        //    if (!await _roleManager.RoleExistsAsync("User"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        //    }

        //    return Content("role yarandi");
        //}

        #endregion
    }
}
