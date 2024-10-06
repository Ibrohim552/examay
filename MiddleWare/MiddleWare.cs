using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;
    private int _requestCount = 0;
    private const int LimitRequest = 10;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        bool isAdmin = context.Request.Headers["Admin"] == "true";
        _requestCount++;

        if (!isAdmin && _requestCount > LimitRequest)
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Превышен лимит запросов. Попробуйте позже.");
            return;
        }

        await _next(context);
    }
}