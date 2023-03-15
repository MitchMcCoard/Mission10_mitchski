using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission10_mitchski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:BookstoreConnection"]);
           });

            services.AddScoped<IBookstoreReposotory, EFBookstoreRepository>();
            services.AddScoped<ITransactionRepository, EFTransactionRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();

            //Get a new basket, if there isn't one
            services.AddScoped<Basket>(x => SessionBasket.GetBasket(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            //Corresponds to wwwroot
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //The order matters here, and it can be kinda tricky
                
                //If they pass us both the page number and the category
                endpoints.MapControllerRoute(
                    name: "typepage",
                    pattern: "{category}/{pageNum}",
                    defaults: new { Controller = "Home", action = "Index" }
                    );


                //Cleans up the slug (in the url)
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 }
                    );

                //If they only select the category
                endpoints.MapControllerRoute(
                    name: "type",
                    pattern: "{category}",
                    new {Controller = "Home", action = "Index", pageNum=1}
                    );

                

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });
        }
    }
}
