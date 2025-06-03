
using LangCommerce.Domain.Entities;

namespace LangCommerce.Application.DTOs.Product;

public class ProductFullDto
{
    public int ProductId { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsPublished { get; set; }

    public ICollection<ProductTranslationDto> Translations { get; set; } = new List<ProductTranslationDto>();
}
