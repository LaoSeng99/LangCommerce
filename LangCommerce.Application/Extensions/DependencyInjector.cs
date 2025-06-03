
using LangCommerce.Application.Context;
using LangCommerce.Application.DTOs;
using LangCommerce.Application.Mapping;
using LangCommerce.Application.Services.Interfaces.Product;
using LangCommerce.Application.Services.Interfaces.UserAccess;
using LangCommerce.Application.Services.Product;
using LangCommerce.Application.Services.UserAccess;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;

namespace LangCommerce.Application.Extensions;

public static class DependencyInjector
{
    public static void ConfigureAppServices(this IServiceCollection services)
    {
        services.AddSwaggerExamplesFromAssemblyOf<IExampleFilter>();
        services.AddSwaggerGen(c =>
        {
            c.ExampleFilters();
        });

        services.AddScoped<UserContext>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();


        services.AddScoped<IProductAppService, ProductAppService>();

        MapsterConfig.RegisterMappings();

    }
}
