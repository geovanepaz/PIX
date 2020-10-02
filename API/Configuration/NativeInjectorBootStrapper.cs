using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Pix.Application.Services;
using Pix.Application.ViewModels.Login;
using Pix.Application.ViewModels.Validations;
using Pix.Domain;
using Pix.Infra.Contexts;
using Pix.Infra.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Configuration
{
    public static class NativeInjectorBootStrapper
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            //Validator 
            services.AddTransient<IValidator<LoginRequest>, LoginValidator>();
            services.AddTransient<IValidator<UsuarioRequest>, UsuarioValidator>();

            //Repository
            services.AddScoped<IClienteRepository, ClienteRepository>();

            //Appsercice
            services.AddScoped<IClienteAppService, ClienteAppService>();

            //Context
            services.AddScoped<PixContext>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        }
    }
}
