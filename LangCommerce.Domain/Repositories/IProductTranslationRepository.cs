
using LangCommerce.Domain.Entities;

namespace LangCommerce.Domain.Repositories;

public interface IProductTranslationRepository
{
    Task<ProductTranslation> GetTranslationByIdAsync(string code, int productId);
    Task<List<ProductTranslation>> GetTranslationsByIdsAsync(string code, List<int> productIds);
}
