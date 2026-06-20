using Microsoft.AspNetCore.Diagnostics;
using Planilharias.Domain.Exceptions;

namespace Planilharias.Api.ExceptionHandling;

public sealed class DomainExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, code, message) = exception switch
        {
            BaseDomainException domain => (StatusCodes.Status400BadRequest, domain.Code, domain.Message),
            KeyNotFoundException       => (StatusCodes.Status404NotFound, "resource.notFound", "Resource not found."),
            _                          => (0, null, null),
        };

        if (code is null)
        {
            return false;
        }

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(new { code, message }, cancellationToken);

        return true;
    }
}