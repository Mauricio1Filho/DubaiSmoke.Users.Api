using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Infrastructure.Repositories.Mongo;
using DubaiSmoke.Users.Infrastructure.Repositories.MySql;
using Microsoft.Extensions.DependencyInjection;

namespace DubaiSmoke.Users.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependeciesRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IAddressRepository, AddressRepository>();
            serviceCollection.AddScoped<IContactRepository, ContactRepository>();
            serviceCollection.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            serviceCollection.AddScoped<IUserAggregateRepository, UserAggregateRepository>();
        }
    }
}
