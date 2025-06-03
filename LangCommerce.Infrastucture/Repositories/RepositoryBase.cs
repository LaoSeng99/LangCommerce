

using LangCommerce.Domain.Repositories;
using LangCommerce.Infrastucture.Persistence;

namespace LangCommerce.Infrastucture.Repositories;

internal class RepositoryBase<T>(
    AppDbContext _db
    ) : IRepositoryBase<T> where T : class
{
    public async Task AddAsync(T entity)
    {
        await _db.Set<T>().AddAsync(entity);
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
