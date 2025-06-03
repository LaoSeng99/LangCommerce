

using LangCommerce.Application.DTOs.Product;
using LangCommerce.Application.Services.Interfaces.Product;
using LangCommerce.Infrastucture.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LangCommerce.Infrastucture.Services.Product;

internal class ProductDtoService(AppDbContext _db) : IProductDtoService
{
    private IQueryable<Domain.Entities.Product> BaseQuery(bool asNoTracking = false)
    {
        var query = _db.Set<Domain.Entities.Product>();
        return asNoTracking ? query.AsNoTracking() : query;
    }

    public async Task<List<ProductFullDto>> GetAllDtoAsync()
    {
        return await BaseQuery().ProjectToType<ProductFullDto>().ToListAsync();
    }
}
