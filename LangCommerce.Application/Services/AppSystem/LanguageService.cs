
using LangCommerce.Application.Services.Interfaces.AppSystem;
using LangCommerce.Domain.Entities;
using LangCommerce.Domain.Repositories;

namespace LangCommerce.Application.Services.AppSystem;

internal class LanguageService(
    ILanguageRepository repo
    ) : ILanguageService
{
    public async Task<List<Language>> GetAllAsync()
    {
        return await repo.GetAllAsync();
    }
}
