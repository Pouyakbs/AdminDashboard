using AdminDashboard.Core.ApplicationService.Config;
using AdminDashboard.Core.ApplicationService.Facade;
using AdminDashboard.Core.ApplicationService.UnitofWork;
using AdminDashboard.Core.Contracts.Facade;
using AdminDashboard.Core.Contracts.Repository;
using AdminDashboard.Core.Contracts.Repository.Common;
using AdminDashboard.Core.Contracts.UnitofWork;
using AdminDashboard.Infrastructure.Data;
using AdminDashboard.Infrastructure.Data.Common;
using AdminDashboard.Infrastructure.EF;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationHost
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
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProductsProfile());
                mc.AddProfile(new SellManagementProfile());
                mc.AddProfile(new StoreProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddDbContext<DemoContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(
                    Configuration.GetConnectionString("MasalanExam"));
            });
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ISellManagementRepository, SellManagementRepository>();
            services.AddScoped<IGenericRepository<IProductsRepository>, GenericRepository<IProductsRepository>>();
            services.AddScoped<IGenericRepository<ISellManagementRepository>, GenericRepository<ISellManagementRepository>>();
            services.AddScoped<IGenericRepository<IStoreRepository>, GenericRepository<IStoreRepository>>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IProductsFacade, ProductsFacade>();
            services.AddScoped<ISellManagementFacade, SellManagementFacade>();
            services.AddScoped<IStoreFacade, StoreFacade>();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
