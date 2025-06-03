

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LangCommerce.Domain.Entities;

public class ProductTranslation
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public string LanguageCode { get; set; } // e.g. "en", "zh", "ms"

    #region Only These need to translate
    public string Name { get; set; }
    public string Description { get; set; }
    #endregion
    public virtual Product Product { get; set; }
}
