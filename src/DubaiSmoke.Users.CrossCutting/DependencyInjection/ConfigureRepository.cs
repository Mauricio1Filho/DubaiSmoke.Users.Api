using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Infrastructure.Repositories.MySql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using Repositories.UnitOfWork;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.CrossCutting.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class ConfigureRepository
    {
        public static void ConfigureDependeciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IAddressRepository, AddressRepository>();
            serviceCollection.AddScoped<IContactRepository, ContactRepository>();
            serviceCollection.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(_ => new UnitOfWork(configuration.GetConnectionString("dubaismokedb")));
        }
    }
}
