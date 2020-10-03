namespace Core.Domain
{
    using Common.Domain.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .AddCommonDomain();
                //.AddTransient<IRentingScheduleService, RentingScheduleService>();
    }
}
