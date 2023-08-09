using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCDHProject.IRepository;
using MVCDHProject.Models;
using MVCDHProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace MVCDHProject
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
            services.AddControllersWithViews(configure =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddScoped<ICustomerXmlDAL, CustomerXmlDAL>();
            services.AddScoped<ICustomerSqlDAL, CustomerSqlDAL>();
            services.AddDbContext<MVCCoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConStr"));
            });
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<MVCCoreDbContext>().AddDefaultTokenProviders();
            services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = "138152674013-fp9k3qn8dso0gijk0hvme1ej6daskov5.apps.googleusercontent.com";
                options.ClientSecret = "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";
            })
            .AddFacebook(options =>
            {
                options.AppId = "615855737353790";
                options.AppSecret = "571f2036e32a8b182ea0590d1f316959";
            });
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
                app.UseStatusCodePagesWithRedirects("/ClientError/{0}");
                //app.UseStatusCodePages();
                app.UseStatusCodePagesWithRedirects("/ClientError/{0}");
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Customer}/{action=DisplayCustomers}/{id?}");
            });
        }
    }
}
