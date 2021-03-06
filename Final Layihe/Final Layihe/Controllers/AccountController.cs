using Final_Layihe.Models;
using Final_Layihe.ViewModels.Account;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Final_Layihe.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _manager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _enviroment;

        public AccountController(UserManager<AppUser> manager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment enviroment)
        {
            _manager = manager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _enviroment = enviroment;
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

            if (appUser.EmailConfirmed == false)
            {
                return RedirectToAction("Index", "Home");
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

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Ulvi", "ulvialekberov97@gmail.com"));
            message.To.Add(new MailboxAddress(appUser.Name, appUser.Email));
            message.Subject = "Emaili Tesdiqleyin";

            string emailbody = string.Empty;

            using(StreamReader stream = new StreamReader(Path.Combine(_enviroment.WebRootPath, "template", "email.html")))
            {
                emailbody = stream.ReadToEnd();
            }

            string emailconfirmtoken = await _manager.GenerateEmailConfirmationTokenAsync(appUser);
            string url = Url.Action("confirmemail", "account", new { Id = appUser.Id, token= emailconfirmtoken }, Request.Scheme);
            emailbody = emailbody.Replace("{{fullName}}", $"{ appUser.Name} { appUser.SurName}").Replace("{{url}}", $"{ url}");
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("ulvialekberov97@gmail.com", "ulvi1999");
            smtp.Send(message);
            smtp.Disconnect(true);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ConfirmEmail(string Id, string token)
        {
            if (string.IsNullOrWhiteSpace(Id)|| string.IsNullOrWhiteSpace(token))
            {
                return NotFound();
            }

            AppUser appUser = await _manager.FindByIdAsync(Id);
            if (appUser == null) 
            {
                return NotFound();
            }

            IdentityResult identityResult = await _manager.ConfirmEmailAsync(appUser, token);
            if (!identityResult.Succeeded) 
            {
                return NotFound();
            }

            return RedirectToAction("Login");

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return NotFound();

            AppUser appUser = await _manager.FindByEmailAsync(email);

            if (appUser == null)
                return NotFound();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Ulvi", "ulvialekberov97@gmail.com"));
            message.To.Add(new MailboxAddress(appUser.Name, appUser.Email));
            message.Subject = "Şifrəni Yeniləyin";

            string emailbody = string.Empty;

            using (StreamReader stream = new StreamReader(Path.Combine(_enviroment.WebRootPath, "template", "forgetpassword.html")))
            {
                emailbody = stream.ReadToEnd();
            }

            string forgetpassword = await _manager.GeneratePasswordResetTokenAsync(appUser);
            string url = Url.Action("changepassword", "account", new { Id = appUser.Id, token = forgetpassword }, Request.Scheme);
            emailbody = emailbody.Replace("{{fullName}}", $"{ appUser.Name} { appUser.SurName}").Replace("{{url}}", $"{ url}");
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("ulvialekberov97@gmail.com", "ulvi1999");
            smtp.Send(message);
            smtp.Disconnect(true);

            return View();
        }
       
       public async Task<IActionResult> ChangePassword(string Id, string token)
        {
            if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(token))
            {
                return NotFound();
            }

            AppUser appUser = await _manager.FindByIdAsync(Id);
            if (appUser == null)
            {
                return NotFound();
            }


            ForgetPassVM forgetPassVM = new ForgetPassVM
            {
                Id = Id,
                Token = token
            };

            return View(forgetPassVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ForgetPassVM forgetPassVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(forgetPassVM.Id) || string.IsNullOrWhiteSpace(forgetPassVM.Token))
            {
                return NotFound();
            }

            AppUser appUser = await _manager.FindByIdAsync(forgetPassVM.Id);
            if (appUser == null)
            {
                return NotFound();
            }

            IdentityResult identityResult = await _manager.ResetPasswordAsync(appUser, forgetPassVM.Token, forgetPassVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(forgetPassVM);
            }

            return RedirectToAction("Login");
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
