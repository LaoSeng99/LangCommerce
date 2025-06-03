
using LangCommerce.Application.Context;
using LangCommerce.Application.DTOs.Product;
using LangCommerce.Application.Services.Interfaces.Product;
using LangCommerce.Domain.Entities;
using LangCommerce.Domain.Repositories;
using Mapster;

namespace LangCommerce.Application.Services.Product;

public class ProductAppService(
    UserContext _userContext,
    IProductRepository repo,
    IProductTranslationRepository transPdRepo
    ): IProductAppService
{
    public async Task<List<ProductAppDto>> GetAllDtoAsync()
    {
        var products = await repo.GetAllAsync();

        if (_userContext.IsEnglish)
        {
            return products
                      .Select(p => (product: p, translation: (ProductTranslation?)null))
                      .Adapt<List<ProductAppDto>>();
        }

        var productIds = products.Select(p => p.Id).ToList();
        var translations = await transPdRepo.GetTranslationsByIdsAsync(_userContext.LanguageCode, productIds);

        var transDict = translations.ToDictionary(t => t.ProductId);
        var pairs = products.Select(p =>
            (product: p, translation: transDict.TryGetValue(p.Id, out ProductTranslation? value) ? value : null)
        );

        return pairs.Adapt<List<ProductAppDto>>();
    }
}
