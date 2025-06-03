using LangCommerce.Application.Context;

namespace LangCommerce.API.Middlewares;

public class UserContextMiddleware(UserContext userContext) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string? langCode = null;

        if (context.Request.Headers.TryGetValue("X-AppUser-Language", out var headerLang))
        {
            langCode = headerLang.ToString().Split(',').FirstOrDefault();
        }
        else if (context.Request.Cookies.TryGetValue("AppUser.Language", out var cookieLang))
        {
            langCode = cookieLang;
        }
        userContext.LanguageCode = string.IsNullOrWhiteSpace(langCode) ? "en-US" : langCode;

        await next(context);
    }
}
