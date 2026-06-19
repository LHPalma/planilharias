using Microsoft.AspNetCore.Http;
using Planilharias.Domain.Workbooks.Exceptions;
using Planilharias.Api.ExceptionHandling;

namespace Planilharias.Tests.Api.ExceptionHandling;

public class DomainExceptionHandlerTests
{
    private readonly DomainExceptionHandler _handler = new();

    [Fact(DisplayName = "Mapeia exceção de domínio para 400")]
    public async Task TryHandleAsync_WithDomainException_SetsBadRequest()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var exception = new WorkbookNameTooLongException(120);

        // Act
        var handled = await _handler.TryHandleAsync(context, exception, CancellationToken.None);

        // Assert
        Assert.True(handled);
        Assert.Equal(StatusCodes.Status400BadRequest, context.Response.StatusCode);
    }
}