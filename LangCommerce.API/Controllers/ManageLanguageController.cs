using LangCommerce.Application.Services.Interfaces.AppSystem;
using LangCommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LangCommerce.API.Controllers;

[Route("api/admin/language")]
[ApiController]
[Tags("Admin - Manage Language")]
[Produces("application/json")]
public class ManageLanguageController(
    ILanguageService service
    ) : Controller
{
    /// <summary>
    /// Retrieves all available languages configured in the system.
    /// </summary>
    /// <returns>List of <see cref="Language"/> representing supported languages.</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(Language), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var data = await service.GetAllAsync();

        return Ok(data);
    }

    /// <summary>
    /// Sets the preferred language for the current user by storing it in a secure cookie.
    /// </summary>
    /// <param name="code">The language code to set (e.g., "en-US", "zh-CN").</param>
    /// <returns>Confirmation of the selected language code.</returns>
    [HttpPost("set-language")]
    [ProducesResponseType(typeof(Language), StatusCodes.Status200OK)]
    public async Task<IActionResult> SetLanguage(string code)
    {
        Response.Cookies.Append("AppUser.Language", code, new CookieOptions
        {
            HttpOnly = false,
            Secure = true, 
            SameSite = SameSiteMode.Lax,
            Expires = DateTimeOffset.UtcNow.AddYears(1)
        });

        return Ok(new { message = "Language set", code });
    }
}
