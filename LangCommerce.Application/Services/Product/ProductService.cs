
using LangCommerce.Application.Context;
using LangCommerce.Application.DTOs.Product;
using LangCommerce.Application.Services.Interfaces.Product;
using LangCommerce.Domain.Repositories;
using Mapster;

namespace LangCommerce.Application.Services.Product;

public class ProductService(
    UserContext _userContext,
    IProductRepository repo,
    IProductTranslationRepository transPdRepo
    ) : IProductService
{
    public async Task Create(CreateProductRequest req)
    {
        var product = req.Adapt<Domain.Entities.Product>();

        await repo.CreateAsync(product);

        await repo.SaveAsync();
    }
}
