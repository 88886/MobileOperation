using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using MobileOperation.Models;

namespace MobileOperation
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddDbContext<MOContext>(x => x.UseSqlite("Data source=mobileoperation.db"))
                .AddSqlite();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MOContext>()
                .AddDefaultTokenProviders();

            services.AddFileUpload()
                .AddEntityFrameworkStorage<MOContext>();

            services.AddMvc();
            services.AddSmartUser<User, string>();
            services.AddSmartCookies();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseIdentity();
            app.UseIISPlatformHandler();
            app.UseFileUpload();
            app.UseMvcWithDefaultRoute();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
