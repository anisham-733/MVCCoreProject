using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MVCCore1.Models;
using MVCCore1.Repositories;
using MVCCore1.Services;
using MVCCore1.Services.AppConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public  void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc();
            string conStr = this.Configuration.GetConnectionString("Conn");
            //string AzureConnection = this.Configuration.GetConnectionString("AccessKey");

            var config = Configuration.GetSection(AppSettings.sections);

            services.AddDbContext<mydatabaseContext>(options => options.UseSqlServer(conStr));
            services.Configure<AppSettings>(config);

           
            services.AddTransient<IService,Service>();
            
            services.AddTransient<IOperations,Operations>();
            services.AddTransient<IAzureService,AzureService>();
            services.AddControllersWithViews();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Image}/{action=add}/{id?}");
            });
        }
    }
}
