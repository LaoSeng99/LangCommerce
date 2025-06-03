
using LangCommerce.Domain.Entities;
using LangCommerce.Domain.Repositories;
using LangCommerce.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LangCommerce.Infrastucture.Repositories;

internal class ProductTranslationRepository(AppDbContext _db)
    : IProductTranslationRepository
{
    private IQueryable<ProductTranslation> BaseQuery(bool asNoTracking = false)
    {
        var query = _db.Set<ProductTranslation>();
        return asNoTracking ? query.AsNoTracking() : query;
    }

    public async Task<List<ProductTranslation>> GetTranslationsByIdsAsync(string code, List<int> productIds)
    {
        return await BaseQuery().Where(c => c.LanguageCode == code && productIds.Contains(c.ProductId)).ToListAsync() ;
    }

    public async Task<ProductTranslation> GetTranslationByIdAsync(string code, int productId)
    {
        return await BaseQuery().Where(c => c.LanguageCode == code && c.ProductId == productId).FirstOrDefaultAsync() ?? null!;
    }
}
