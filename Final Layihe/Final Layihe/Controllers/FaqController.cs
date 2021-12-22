using Final_Layihe.DAL;
using Final_Layihe.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.Controllers
{
    public class FaqController : Controller
    {
        private readonly AppDbContext _context;
        public FaqController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            FaqVM faqVM = new FaqVM()
            {
                Faq = await _context.Faqs.FirstOrDefaultAsync(),
                Faqres = await _context.Faqres.ToListAsync()
            };
            return View(faqVM);
        }
    }
}
