using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageEmplyees.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Manage_Emplyees
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AuthenticationContext>(options =>
                options.UseSqlServer("Server=(localDB)\\MSSQLLocalDB;Database=ManagesEmployeesDB;Trusted_Connection=true;MultipleActiveResultSets=True;"));
            //"Data Source=SQL5045.site4now.net;Initial Catalog=DB_A54E91_Osama;User Id=DB_A54E91_Osama_admin;Password=Osama1996^_^;"
            //Server=(localDB)\\MSSQLLocalDB;Database=ManagesGlobitelEmployeesDB;Trusted_Connection=true;MultipleActiveResultSets=True;

            services.AddDefaultIdentity<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
            }
                     );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
