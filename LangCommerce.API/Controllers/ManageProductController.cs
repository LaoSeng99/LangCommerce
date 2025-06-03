using LangCommerce.Application.DTOs.Product;
using LangCommerce.Application.Services.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;

namespace LangCommerce.API.Controllers;


[Route("api/admin/products")]
[ApiController]
[Tags("Admin - Manage Products")]
[Produces("application/json")]
public class ManageProductController(
    IProductDtoService dtoService,
    IProductService service
    ) : ControllerBase
{
    /// <summary>
    /// Retrieves all products including all language translations.
    /// </summary>
    /// <returns>List of <see cref="ProductFullDto"/> containing all product data with translations.</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(ProductFullDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var data = await dtoService.GetAllDtoAsync();

        return Ok(data);
    }

    /// <summary>
    /// Creates sample product data.
    /// </summary>
    /// <param name="req">The product creation request payload.</param>
    /// <returns>Boolean status indicating success.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest req)
    {
        await service.Create(req);
        return Ok(true);
    }
}
