
using LangCommerce.Domain.Entities;
using LangCommerce.Domain.Repositories;
using LangCommerce.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LangCommerce.Infrastucture.Repositories;

internal class ProductRepository(AppDbContext _db) : 
    RepositoryBase<Product>(_db),
    IProductRepository
{
    private IQueryable<Product> BaseQuery(bool asNoTracking = false)
    {
        var query = _db.Set<Product>();
        return asNoTracking ? query.AsNoTracking() : query;
    }

    public async Task CreateAsync(Product product)
    {
        await _db.Set<Product>().AddAsync(product);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await BaseQuery().ToListAsync();
    }


}
