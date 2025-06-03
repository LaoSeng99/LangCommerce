using System.Reflection;
using LangCommerce.API.Middlewares;
using LangCommerce.Application.Context;
using LangCommerce.Infrastucture.Settings;
using Microsoft.OpenApi.Models;

namespace LangCommerce.API.Extensions;

public static class DependencyInjector
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DataFilesOptions>(configuration);

        services.AddScoped<UserContextMiddleware>();

        services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            //Any class name
            var appXmlFile = $"{typeof(UserContext).Assembly.GetName().Name}.xml";
            var appXmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, appXmlFile);
            c.IncludeXmlComments(appXmlPath);


            c.AddSecurityRequirement(new OpenApiSecurityRequirement{
            {
                new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }});
        });

    }
}
