using Microsoft.AspNetCore.Diagnostics;

namespace ProductApi.Middlewares;
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger=logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext
    ,Exception exception
    ,CancellationToken cancellationToken)
    {
        _logger.LogError(exception,"An Unhandled Exception Occurred.");
        httpContext.Response.StatusCode=StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(
            new{
                statusCode=500,
                message="An UnExpected error Occurred."
            },cancellationToken
        );
        return true;
    }
}