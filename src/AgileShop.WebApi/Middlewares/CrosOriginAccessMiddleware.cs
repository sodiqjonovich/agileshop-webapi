using AgileShop.Domain.Exceptions;
using Newtonsoft.Json;
using Serilog;

namespace AgileShop.WebApi.Middlewares;

public class CrosOriginAccessMiddleware
{
    private readonly RequestDelegate _next;
    public CrosOriginAccessMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, IWebHostEnvironment env)
    {
        httpContext.Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
        await _next(httpContext);
    }
}
