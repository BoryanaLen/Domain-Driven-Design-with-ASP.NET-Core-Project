namespace Core.Infrastructure
{
    using System;
    using System.Reflection;
    using AutoMapper;
    using Common.Infrastructure.Events;
    using Core.Application.Hotel.Reservations;
    using Core.Infrastructure.Persistence;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<HotelSystemDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddTransient<IEventDispatcher, EventDispatcher>();

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IReservationQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
