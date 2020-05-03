using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
using Serilog;
using System.Web.Http;
using Microsoft.OpenApi.Models;

namespace SWMNU.Net.TestingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var controllerBuilder = services.AddControllersWithViews();
            var razorBuilder = services.AddRazorPages();
            // Derived from: https://www.fanray.com/post/2019/11/02/auto-recompile-razor-class-library-during-development-with-asp-net-core-3
#if DEBUG
            if (Environment.IsDevelopment())
            {
                string[] dirs = { "FlashMessage.Src", "FlashMessage.TestingApp" };
                controllerBuilder.AddRazorRuntimeCompilation(options =>
                {
                    foreach (var dir in dirs)
                    {
                        var libraryPath = Path.GetFullPath(Path.Combine(Environment.ContentRootPath, "..", dir));
                        options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
                    }
                });

                razorBuilder.AddRazorRuntimeCompilation(options =>
                {
                    foreach (var dir in dirs)
                    {
                        var libraryPath = Path.GetFullPath(Path.Combine(Environment.ContentRootPath, "..", dir));
                        options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
                    }
                });
            }
#endif
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "test", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "test");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
                endpoints.MapRazorPages();               
            });
        }
    }
}
