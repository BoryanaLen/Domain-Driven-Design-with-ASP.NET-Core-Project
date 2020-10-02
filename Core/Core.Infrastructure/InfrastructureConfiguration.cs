namespace Core.Infrastructure
{
    using System.Text;
    using Common.Application;
    using Common.Application.Contracts;
    using Common.Application.Identity;
    using Common.Domain;
    using Common.Infrastructure;
    using Common.Infrastructure.Events;
    using Identity;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Persistence;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories()
                .AddFactories()
                .AddIdentity(configuration)
                .AddTransient<IEventDispatcher, EventDispatcher>();

        private static IServiceCollection AddInitialData(this IServiceCollection services)
          => services
              .Scan(scan => scan
                  .FromCallingAssembly()
                  .AddClasses(classes => classes
                      .AssignableTo(typeof(IInitialData)))
                  .AsImplementedInterfaces()
                  .WithTransientLifetime());

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<HotelSystemDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(HotelSystemDbContext).Assembly.FullName)))
                .AddTransient<IInitializer, DatabaseInitializer>()
                .AddInitialData();

        private static IServiceCollection AddFactories(this IServiceCollection services)
          => services
              .Scan(scan => scan
                  .FromCallingAssembly()
                  .AddClasses(classes => classes
                      .AssignableTo(typeof(IFactory<>)))
                  .AsMatchingInterface()
                  .WithTransientLifetime());

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IDomainRepository<>))
                        .AssignableTo(typeof(IQueryRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

        private static IServiceCollection AddIdentity(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<HotelSystemDbContext>();

            var secret = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);


            services.AddTransient<IIdentity, IdentityService>();
            services.AddTransient<IJwtTokenGenerator, JwtTokenGeneratorService>();

            return services;
        }
    }
}
