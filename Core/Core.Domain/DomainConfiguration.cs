namespace Core.Domain
{
    using Common.Domain;
    using Common.Domain.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .AddCommonDomain()
                .AddInitialData()
                .AddFactories();

        //.AddTransient<IRentingScheduleService, RentingScheduleService>();

        private static IServiceCollection AddInitialData(this IServiceCollection services)
           => services
               .Scan(scan => scan
                   .FromCallingAssembly()
                   .AddClasses(classes => classes
                       .AssignableTo(typeof(IInitialData)))
                   .AsImplementedInterfaces()
                   .WithTransientLifetime());

        private static IServiceCollection AddFactories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
    }
}
