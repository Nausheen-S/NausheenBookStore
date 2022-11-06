using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using NausheenBookStore.Data; remove this since path is dataaccess.data
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NausheenBookStore.DataAccess.Data; //added new 
using NausheenBooks.DataAccess.Repository;
using NausheenBooks.DataAccess.Repository.IRepository; //adding using statements


namespace NausheenBookStore
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>() //removed the options: options => options.SignIn.RequireConfirmedAccount = true
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //adding interface reference
            services.AddScoped<IUnitOfWork, UnitOfWork>(); //check if IUnit or Unit - error resolved after implementing inheritence in unitofwork class
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();//configuring for HTTP Pipeline
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
                app.UseEndpoints(endpoints =>
            {
                //added endpoint for areas
                endpoints.MapAreaControllerRoute(
                  name: "Areas",
                  areaName: "Customer",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //admin
                endpoints.MapAreaControllerRoute(
                 name: "Areas",
                 areaName: "Admin",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
        //adding routes to accomodate areas
        /*pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");*/
                endpoints.MapRazorPages();
            });
           
           
        }
    }
}
