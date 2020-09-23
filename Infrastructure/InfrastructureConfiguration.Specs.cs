namespace Infrastructure
{
    using System;
    using System.Reflection;
    using AutoMapper;
    using Common.Persistence;
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            //// Arrange
            //var serviceCollection = new ServiceCollection()
            //    .AddDbContext<HotelDbContext>(opts => opts
            //        .UseInMemoryDatabase(Guid.NewGuid().ToString()))
            //    .AddTransient(_ => A.Fake<IDealershipDbContext>());

            //// Act
            //var services = serviceCollection
            //    .AddAutoMapper(Assembly.GetExecutingAssembly())
            //    .AddRepositories()
            //    .BuildServiceProvider();

            //// Assert
            //services
            //    .GetService<ICarAdRepository>()
            //    .Should()
            //    .NotBeNull();
        }
    }
}
