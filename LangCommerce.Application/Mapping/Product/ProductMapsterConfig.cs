
using LangCommerce.Application.DTOs.Product;
using Mapster;

namespace LangCommerce.Application.Mapping.Product;

public class ProductMapsterConfig : IMapsterConfig
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Domain.Entities.Product, Domain.Entities.Product>();
        config.ForType<
            (Domain.Entities.Product product, Domain.Entities.ProductTranslation? translation),
            ProductAppDto>()
            .Map(dest => dest.ProductId, src => src.product.Id)
            .Map(dest => dest.SKU, src => src.product.SKU)
            .Map(dest => dest.Price, src => src.product.Price)
            .Map(dest => dest.Name, src => src.translation != null && !string.IsNullOrEmpty(src.translation.Name) ? src.translation.Name : src.product.Name)
            .Map(dest => dest.Description, src => src.translation != null && !string.IsNullOrEmpty(src.translation.Description) ? src.translation.Description : src.product.Description);

        config.ForType<Domain.Entities.Product, ProductFullDto>()
            .Map(dest => dest.ProductId, src => src.Id);

        config.ForType<Domain.Entities.ProductTranslation, ProductTranslationDto>()
            .Map(dest => dest.TranslateId, src => src.Id);

        config.ForType<CreateProductRequest, Domain.Entities.Product>()
            .Map(dest => dest.Translations, src => src.Translations);

        config.ForType<CreateProductTranslationRequest, Domain.Entities.ProductTranslation>()
            .Map(dest => dest.LanguageCode, src => src.Code);


    }
}
