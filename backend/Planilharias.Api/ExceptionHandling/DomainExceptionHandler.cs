using Microsoft.AspNetCore.Diagnostics;
using Planilharias.Domain.Exceptions;

namespace Planilharias.Api.ExceptionHandling;

public sealed class DomainExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        if (exception is not BaseDomainException)
        {
            return ValueTask.FromResult(false);
        }

        httpContext
            .Response
            .StatusCode = StatusCodes.Status400BadRequest;
        return ValueTask.FromResult(true);
    }
}