using LangCommerce.Application.Services.Interfaces.Seeders;

namespace LangCommerce.Infrastucture.Persistence.Seeders;

internal class SeederManager(IEnumerable<ISeeder> seeders) : ISeederManager
{
    public async Task SeedAll()
    {
        foreach (var seeder in seeders)
        {
            await seeder.Seed();
        }
    }
}
