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
        if (exception is not BaseDomainException baseDomainException)
        {
            return false;
        }

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        
        await httpContext.Response.WriteAsJsonAsync(
            new
            {
                code = baseDomainException.Code,
                message = baseDomainException.Message,
            }, cancellationToken
        );

        return true;
    }
}