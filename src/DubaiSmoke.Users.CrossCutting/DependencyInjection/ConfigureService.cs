using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.Services;
using DubaiSmoke.Users.CrossCutting.AutoMapper.Profiles;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Domain.Services;
using ErrorHandler.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DubaiSmoke.Users.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependeciesServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IUserServiceApp, UserServiceApp>();
            serviceCollection.AddScoped<IAddressServiceApp, AddressServiceApp>();
            serviceCollection.AddScoped<IAddressService, AddressService>();
            serviceCollection.AddScoped<IContactServiceApp, ContactServiceApp>();
            serviceCollection.AddScoped<IContactService, ContactService>();
            serviceCollection.AddScoped<IContactTypeServiceApp, ContactTypeServiceApp>();
            serviceCollection.AddScoped<IContactTypeService, ContactTypeService>();
            serviceCollection.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddScoped<ErrorHandlerNotification>();
            serviceCollection.AddAutoMapper(typeof(DomainToViewModelProfile), typeof(ViewModelToDomainProfile));
        }
    }
}
