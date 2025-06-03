
using LangCommerce.Application.DTOs.Product;

namespace LangCommerce.Application.Services.Interfaces.Product;

public interface IProductService
{
    Task Create(CreateProductRequest req);
}
