
using LangCommerce.Application.Services.Interfaces.Product;
using LangCommerce.Application.Services.Interfaces.Seeders;
using LangCommerce.Domain.Repositories;
using LangCommerce.Infrastucture.Persistence;
using LangCommerce.Infrastucture.Persistence.Seeders;
using LangCommerce.Infrastucture.Repositories;
using LangCommerce.Infrastucture.Services.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LangCommerce.Infrastucture.Extensions;

public static class DependencyInjector
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {


        string connString = configuration.GetConnectionString("DbConnection")!;
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connString,
             o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }, ServiceLifetime.Scoped);

        #region Seeders
        services.AddScoped<ISeeder, LanguageSeeder>();
        services.AddScoped<ISeederManager, SeederManager>();
        #endregion

        #region Repo DI
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductTranslationRepository, ProductTranslationRepository>();
        #endregion

        #region Service DI
        services.AddScoped<IProductDtoService, ProductDtoService>();
        #endregion

    }
}
