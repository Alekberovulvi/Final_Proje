using Final_Layihe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Bounce> Bounces { get; set; }
        public virtual DbSet<BounceImg> BounceImgs { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<Faqres> Faqres { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Papadias> Papadias { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Brithday> Brithdays { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Snack> Snacks { get; set; }
        public virtual DbSet<Salat> Salats { get; set; }

    }
}
