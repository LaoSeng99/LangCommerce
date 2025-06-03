
using LangCommerce.Application.DTOs.Product;

namespace LangCommerce.Application.Services.Interfaces.Product;

public interface IProductDtoService
{
    Task<List<ProductFullDto>> GetAllDtoAsync();
}
