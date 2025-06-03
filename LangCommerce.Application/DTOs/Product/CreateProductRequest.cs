using Swashbuckle.AspNetCore.Filters;


namespace LangCommerce.Application.DTOs.Product;

public class CreateProductRequest : IExamplesProvider<CreateProductRequest>, IExampleFilter
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string SKU { get; set; }
    public decimal Price { get; set; }
    public bool IsPublished { get; set; }
    public ICollection<CreateProductTranslationRequest> Translations { get; set; } = new List<CreateProductTranslationRequest>();

    public CreateProductRequest GetExamples()
    {
        return new CreateProductRequest
        {
            Name = "Sample Product",
            Description = "This is a sample product for demonstration.",
            SKU = "SAMPLE-001",
            Price = 99.90m,
            IsPublished = true,
            Translations = new List<CreateProductTranslationRequest>
            {
                new CreateProductTranslationRequest
                {
                    Code = "en-US",
                    Name = "Sample Product",
                    Description = "This is a sample product."
                },
                new CreateProductTranslationRequest
                {
                    Code = "zh-CN",
                    Name = "示例产品",
                    Description = "这是一个用于演示的示例产品。"
                },
                new CreateProductTranslationRequest
                {
                    Code = "ms-MY",
                    Name = "Produk Contoh",
                    Description = "Ini adalah produk contoh untuk demonstrasi."
                },
                new CreateProductTranslationRequest
                {
                    Code = "ta-MY",
                    Name = "மாதிரி தயாரிப்பு",
                    Description = "இது ஒரு மாதிரி தயாரிப்பு, விளக்கத்திற்காக பயன்படுத்தப்படுகிறது."
                }
            }
        };
    }
}
