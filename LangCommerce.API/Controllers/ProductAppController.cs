using LangCommerce.Application.DTOs.Product;
using LangCommerce.Application.Services.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;

namespace LangCommerce.API.Controllers;

[Route("api/app/products")]
[ApiController]
[Tags("App - Products")]
[Produces("application/json")]
public class ProductAppController(
    IProductAppService appService) : ControllerBase
{
    /// <summary>
    /// Retrieves products with translations based on the current request's language.
    /// </summary>
    /// <returns>List of <see cref="ProductAppDto"/> localized to the request language.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ProductAppDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var data = await appService.GetAllDtoAsync();
        return Ok(data);
    }

}
