
using LangCommerce.Application.Services.Interfaces.Seeders;
using LangCommerce.Domain.Entities;
using LangCommerce.Infrastucture.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LangCommerce.Infrastucture.Persistence.Seeders;

internal class LanguageSeeder(AppDbContext _db, IOptions<DataFilesOptions> _options) : ISeeder
{
    private readonly string _languagesFilePath = Path.Combine(AppContext.BaseDirectory, _options.Value.DataFilesPath, "languages.json");
    public async Task Seed()
    {
        if (!await _db.Database.CanConnectAsync())
        {
            return;
        }

        if (_db.Languages.Any())
        {
            return;
        }

        using var transaction = _db.Database.BeginTransaction();
        try
        {
            var data = await GetDefaults();
            if (data.Count == 0)
                return;

            _db.Languages.AddRange(data);

            await _db.SaveChangesAsync();

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    private async Task<List<Language>> GetDefaults()
    {
        var json = await File.ReadAllTextAsync(_languagesFilePath);

        var languages = JsonConvert.DeserializeObject<List<Language>>(json);

        return languages ?? [];
    }
}
