using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//Make sure you make the following imports (AFTER dbcontext and model have been created).
using Lab5.Data;
using Lab5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Mvc;

namespace identityframework
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
            //Default.
            services.AddControllersWithViews();
            //Added by me.
            services.AddRazorPages();
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Make sure you use the Nu-Get Package manager to install: Microsoft.EntityFrameworkCore.SqlServer, otherwise the following line of code will not work.
            //These lines of code are added AFTER you have creater the model and the dbcontext.
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            /*
            // Google service
            
            services.AddAuthentication()
                .AddGoogle(opts  =>
                {
                    opts.ClientId = "946190543560-7j3q279eedskqvqqc0m6si94v7iolq2g.apps.googleusercontent.com";
                    opts.ClientSecret = "4-6qTWWHQub_uEErYEeOHCit";
                    opts.SignInScheme = IdentityConstants.ExternalScheme;
                });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //Default.
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

            //Default.
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            //Added by me.
            app.UseMvcWithDefaultRoute();
            //Added AFTER model and dbcontext have been created.
            app.UseAuthentication();

            /*
             * 
             * Now we can start generating the database. We will be doing things a little bit differently this time.
             * 1-Install:package Microsoft.EntityFrameworkCore.Tools using the Nu-Get Package manager.
             * 2-Install:package Microsoft.EntityFrameworkCore.Tools.DotNet using the Nu-Get Package manager.
             * 3-Right click on solution name and click on Edit Project File.
             * 4-Check to see if they have been added as item groups (they should be by default), in older versions we had to add them manually.
             * 5-Go to the nu-get package manager console and input: Add-Migration InitialCreate
             * 6-If Add-Migration InitialCreate is successfull then input: Update-Database.
             * 7-If successful you should be able to see the database associated with this application.
             * 8-Now let us create new a new model to register the user.

            */


            //Default.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
