using Final_Layihe.DAL;
using Final_Layihe.Models;
using Final_Layihe.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Layihe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)

        {
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddSession(opttions =>
            {
                opttions.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            services.AddIdentity<AppUser, IdentityRole>(identityoption =>
            {
                identityoption.Password.RequireDigit = true;
                identityoption.Password.RequiredLength = 8;
                identityoption.Password.RequireLowercase = true;
                identityoption.Password.RequireUppercase = true;
                identityoption.Password.RequiredUniqueChars = 1;

                identityoption.User.RequireUniqueEmail = true;

                identityoption.Lockout.MaxFailedAccessAttempts = 5;
                identityoption.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                identityoption.Lockout.AllowedForNewUsers = true;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
            services.AddHttpContextAccessor();

            services.AddScoped<LayoutService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("manage/Dashboard/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

              
            });
        }
    }
}
