using LangCommerce.Application.Context;

namespace LangCommerce.API.Middlewares;

public class UserContextMiddleware(UserContext userContext) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Headers.TryGetValue("X-AppUser-Language", out var lang))
        {
            userContext.LanguageCode = lang.ToString().Split(',').FirstOrDefault() ?? "en-US";
        }

        await next(context);
    }

}
