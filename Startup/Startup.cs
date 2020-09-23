namespace Startup
{
    using Application;
    using Domain;
    using Infrastructure;
    using Web;

    using System.Reflection;

    //using CloudinaryDotNet;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Infrastructure.Common.Persistence;

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

            //services.AddDbContext<HotelDbContext>(
            //    options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<HotelUser>(IdentityOptionsProvider.GetIdentityOptions)
            //    .AddRoles<HotelRole>().AddEntityFrameworkStores<HotelDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            //services.AddAuthentication().AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.AppId = this.configuration["Authentication:Facebook:AppId"];
            //    facebookOptions.AppSecret = this.configuration["Authentication:Facebook:AppSecret"];
            //});

            //services.AddAuthentication().AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = this.configuration["Authentication:Google:ClientId"];
            //    googleOptions.ClientSecret = this.configuration["Authentication:Google:ClientSecret"];
            //});

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
            //AutoMapperConfig.RegisterMappings(
            //    typeof(ErrorViewModel).GetTypeInfo().Assembly,
            //    typeof(Room).GetTypeInfo().Assembly,
            //    typeof(DetailsRoomViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                //var dbContext = serviceScope.ServiceProvider.GetRequiredService<HotelDbContext>();

                //if (env.IsDevelopment())
                //{
                //    dbContext.Database.Migrate();
                //}

                //new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

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
