using DubaiSmoke.Users.Application.Validation;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.CrossCutting.Configuration;
using DubaiSmoke.Users.CrossCutting.DependencyInjection;
using DubaiSmoke.Users.CrossCutting.FluentValidation;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace DubaiSmoke.Users.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureDependeciesRepository(Configuration);
            services.ConfigureDependeciesServices();
            DbMapping.InitializeMapping();
            services.AddSwaggerGen();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddTransient<IValidator<UserPayloadViewModel>, UserValidator>();
            services.AddTransient<IValidator<ContactPayloadViewModel>, ContactValidator>();
            services.AddTransient<IValidator<ContactTypePayloadViewModel>, ContactTypeValidator>();
            services.AddTransient<IValidator<AddressPayloadViewModel>, AddressValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dubai Smoke Corp. v1.0");
                c.RoutePrefix = string.Empty;
            });
            var cultureInfo = new CultureInfo("pt-BR");
            cultureInfo.NumberFormat.CurrencySymbol = "R$";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
