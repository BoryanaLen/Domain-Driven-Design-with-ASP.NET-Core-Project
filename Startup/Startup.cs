namespace Startup
{
    using Application;
    using Domain;
    using Infrastructure;
    using Web;

    //using CloudinaryDotNet;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Web.Middleware;
    using AutoMapper;
    using Application.Common.Mapping;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.configuration = configuration;

        private readonly IConfiguration configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDomain()
                .AddApplication(this.configuration)
                .AddInfrastructure(this.configuration)
                .AddWebComponents();

            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddAutoMapper(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            //Account cloudinaryCredentials = new Account(
            //  this.configuration["Cloudinary:CloudName"],
            //  this.configuration["Cloudinary:ApiKey"],
            //  this.configuration["Cloudinary:ApiSecret"]);

            //Cloudinary cloudinaryUtility = new Cloudinary(cloudinaryCredentials);

            //services.AddSingleton(cloudinaryUtility);

            services.AddControllersWithViews(configure =>
            {
                configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repositories
            //services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            //services.AddTransient<IEmailSender>(
            //    serviceProvider => new SendGridEmailSender(this.configuration["SendGrid:ApiKey"]));
            //services.AddTransient<ISettingsService, SettingsService>();
            //services.AddTransient<IRoomsService, RoomsService>();
            //services.AddTransient<ICloudinaryService, CloudinaryService>();
            //services.AddTransient<IRoomTypesService, RoomTypesService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseValidationExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options
                   .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod());

            app.UseAuthentication();

            app.UseAuthentication();

            app.Initialize();

            app.UseHttpsRedirection();

            // Register Syncfusion license
            // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(this.configuration["Syncfusion:LicenseKey"]);

            app.UseDefaultFiles();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
        }
    }
}
