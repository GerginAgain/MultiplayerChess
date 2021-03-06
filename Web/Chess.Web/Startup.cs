using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Chess.Web.Hubs;
using Chess.Data;
using Microsoft.AspNetCore.Mvc;
using Chess.Data.Seeding;
using Chess.Data.Models;
using Chess.Services.Interfaces;
using Chess.Services;
using AutoMapper;
using Chess.Services.Mapping;
using Microsoft.AspNetCore.Identity.UI.Services;
using Chess.Services.Messaging;
using Microsoft.AspNetCore.Http;


namespace Chess.Web
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
            services.AddDbContext<ChessDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true) //������ �� � false
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ChessDbContext>();
            services.Configure<IdentityOptions>(options =>
            {               
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
            services.AddAutoMapper(typeof(AutoMapping));
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(AutoValidateAntiforgeryTokenAttribute));
            });
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });
            services.AddRazorPages();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddSignalR();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Applications services
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddTransient<IGamesService, GamesService>();
            services.AddTransient<IPicturesService, PicturesService>();
            services.AddTransient<IVideosService, VideosService>();
            services.AddTransient<IFavouritesService, FavouritesService>();
            services.AddTransient<IMovesService, MovesService>();
            services.AddTransient<IMessagesService, MessagesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ChessDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new RolesSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {                
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/Error";
                    await next();
                }
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapHub<ChessHub>("/chessHub");
            });
        }
    }
}
