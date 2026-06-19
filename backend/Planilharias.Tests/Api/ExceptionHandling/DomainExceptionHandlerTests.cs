using Microsoft.AspNetCore.Http;
using Planilharias.Api.ExceptionHandling;
using Planilharias.Domain.Workbooks.Exceptions;

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

    [Fact(DisplayName = "Inclui o code da exceção no corpo da resposta")]
    public async Task TryHandleAsync_WithDomainException_WritesCodeInBody()
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();
        var exception = new WorkbookNameTooLongException(120);

        // Act
        await _handler.TryHandleAsync(context, exception, CancellationToken.None);

        // Assert
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        using var reader = new StreamReader(context.Response.Body);
        var body = await reader.ReadToEndAsync();
        Assert.Contains("workbook.name.tooLong", body);
    }

    [Fact(DisplayName = "Mapeia recurso não encontrado para 404")]
    public async Task TryHandleAsync_WithKeyNotFound_SetsNotFound()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var exception = new KeyNotFoundException();

        // Act
        var handled = await _handler.TryHandleAsync(context, exception, CancellationToken.None);

        // Assert
        Assert.True(handled);
        Assert.Equal(StatusCodes.Status404NotFound, context.Response.StatusCode);
    }

    [Fact(DisplayName = "Não trata exceção desconhecida e repassa adiante")]
    public async Task TryHandleAsync_WithUnknownException_ReturnsFalse()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var exception = new InvalidOperationException();

        // Act
        var handled = await _handler.TryHandleAsync(context, exception, CancellationToken.None);

        // Assert
        Assert.False(handled);
        Assert.Equal(StatusCodes.Status200OK, context.Response.StatusCode);
    }
}