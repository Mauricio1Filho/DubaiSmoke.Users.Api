using DubaiSmoke.Users.Application.Validator;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.CrossCutting.Configuration;
using DubaiSmoke.Users.CrossCutting.DependencyInjection;
using DubaiSmoke.Users.CrossCutting.FluentValidation;
using DubaiSmoke.Users.Domain.Config;
using DubaiSmoke.Users.Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System.Globalization;

namespace DubaiSmoke.Users.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureDependeciesRepository();
            services.ConfigureDependeciesServices();
            DbMapping.InitializeMapping();
            services.AddSwaggerGen();

            services.AddMvc().AddFluentValidation(fv =>
            {
               // fv.ImplicitlyValidateChildProperties = true;
            });                   
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddTransient<IValidator<UserPayloadViewModel>, UserValidator>();
            services.AddTransient<IValidator<ContactViewModel>, ContactValidator>();
            services.AddTransient<IValidator<ContactTypeViewModel>, ContactTypeValidator>();
            services.AddTransient<IValidator<AddressViewModel>, AddressValidator>();
            var mongoConfig = new MongoConfig();
            Configuration.Bind("MongoConfig", mongoConfig);
            services.AddSingleton(mongoConfig);
            
            services.AddTransient<IMongoConfigSettings, MongoConfigSettings>();
          

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
