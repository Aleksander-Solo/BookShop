using BookShop.DataAccesLayer;
using BookShop.DataAccesLayer.Entities;
using BookShop.DataAccesLayer.Repository;
using BookShop.DataAccesLayer.Repository.Interfaces;
using BookShop.Heplers;
using BookShop.Heplers.EmailSender;
using BookShop.Middleware;
using BookShop.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop
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
            services.AddDistributedMemoryCache();

            services.AddDbContext<ApplicationDbContext>(option =>
                    option.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ISessionHelper, SessionHelper>();
            services.AddTransient<ApplicationSeeder>();
            services.AddTransient<MapperConfig>();
            services.AddTransient<ErrorHandlingMiddleware>();
            services.AddCloudscribePagination();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICoverAndTypeRepository, CoverAndTypeRepository>();
            services.AddTransient<ICoverAndTypeService, CoverAndTypeService>();
            services.AddTransient<IPublishingHauseRepository, PublishingHauseRepository>();
            services.AddTransient<IPublishingHauseService, PublishingHauseService>();
            services.AddTransient<IPurchaseHistoryRepository, PurchaseHistoryRepository>();
            services.AddTransient<IPurchaseHistoryService, PurchaseHistoryService>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.LoginPath = "/Account/Login";
                    o.AccessDeniedPath = "/Account/AccessDenied";
                });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationSeeder seeder, IServiceProvider serviceProvider)
        {
            seeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Book}/{action=Home}/{id?}");
            });

            serviceProvider.GetService<ApplicationDbContext>().Database.Migrate();
        }
    }
}
