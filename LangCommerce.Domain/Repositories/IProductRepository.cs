
using LangCommerce.Domain.Entities;

namespace LangCommerce.Domain.Repositories;

public interface IProductRepository:IRepositoryBase<Product>
{
    Task CreateAsync(Product product);
    Task<List<Product>> GetAllAsync();
}

