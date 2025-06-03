
using System.ComponentModel.DataAnnotations;

namespace LangCommerce.Domain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsPublished { get; set; }

    public ICollection<ProductTranslation> Translations { get; set; } = new List<ProductTranslation>();
}
