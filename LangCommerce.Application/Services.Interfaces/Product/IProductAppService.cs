
using LangCommerce.Application.DTOs.Product;

namespace LangCommerce.Application.Services.Interfaces.Product;

public interface IProductAppService
{
    Task<List<ProductAppDto>> GetAllDtoAsync();
}
