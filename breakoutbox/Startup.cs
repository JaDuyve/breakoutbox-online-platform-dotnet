﻿using System;
using breakoutbox.Data;
using breakoutbox.Data.Repositories;
using breakoutbox.Models.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace breakoutbox
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
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<BreakoutBoxDataInitializer>();
            services.AddScoped<ISessieRepository, SessieRepository>();
            services.AddScoped<IPadRepository, PadRepository>();
            services.AddScoped<IGroepRepository, GroepRepository>();


            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.CookieName = ".MyApplication";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BreakoutBoxDataInitializer breakoutBoxDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Sessie}/{action=Index}/{id?}");
            });

            app.UseSession();
//            breakoutBoxDataInitializer.InitializeData();
        }
    }
}