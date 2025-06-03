using System.Threading.Tasks;
using LangCommerce.Application.DTOs.Product;
using LangCommerce.Application.Services.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;

namespace LangCommerce.API.Controllers;


[Route("api/admin/products")]
[ApiController]
[Tags("Admin - Manage Products")]
public class ManageProductController(
    IProductDtoService dtoService,
    IProductService service
    ) : ControllerBase
{
    [HttpGet("")]
    [ProducesResponseType(typeof(ProductFullDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var data = await dtoService.GetAllDtoAsync();

        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest req)
    {
        await service.Create(req);
        return Ok(true);
    }
}
