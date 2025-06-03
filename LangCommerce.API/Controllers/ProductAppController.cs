using LangCommerce.Application.DTOs.Product;
using LangCommerce.Application.Services.Interfaces.Product;
using Microsoft.AspNetCore.Mvc;

namespace LangCommerce.API.Controllers;

[Route("api/app/products")]
[ApiController]
[Tags("App - Products")]

public class ProductAppController(
    IProductAppService appService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ProductAppDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var data = await appService.GetAllDtoAsync();
        return Ok(data);
    }

}
