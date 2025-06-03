
using LangCommerce.Domain.Entities;
using LangCommerce.Domain.Repositories;
using LangCommerce.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LangCommerce.Infrastucture.Repositories;

internal class LanguageRepository(AppDbContext _db) :
    RepositoryBase<Language>(_db), ILanguageRepository
{
    private IQueryable<Language> BaseQuery(bool asNoTracking = false)
    {
        var query = _db.Set<Language>();
        return asNoTracking ? query.AsNoTracking() : query;
    }

    public async Task<List<Language>> GetAllAsync()
    {
        return await BaseQuery().ToListAsync();
    }

}
