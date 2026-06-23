using NSubstitute;
using Planilharias.Application.Workbooks.Queries;
using Planilharias.Domain.Workbooks.Models;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Tests.Workbooks.Application.Queries;

public class GetWorkbookByIdQueryHandlerTests
{
    private readonly GetWorkbookByIdQueryHandler _handler;
    private readonly IWorkbookRepository _repository;

    public GetWorkbookByIdQueryHandlerTests()
    {
        _repository = Substitute.For<IWorkbookRepository>();
        _handler = new GetWorkbookByIdQueryHandler(_repository);
    }

    [Fact(DisplayName = "Busca o workbook por id através do repositório")]
    public async Task HandleAsync_WithExistingId_ReturnsWorkbookFromRepository()
    {
        // Arrange
        var id = Guid.NewGuid();
        var workbook = Workbook.Create("Cavalos do Carlinhos");
        _repository.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns(workbook);

        // Act
        var result = await _handler.HandleAsync(new GetWorkbookByIdQuery(id), CancellationToken.None);

        // Assert
        Assert.Same(workbook, result);
        await _repository.Received(1).GetByIdAsync(id, Arg.Any<CancellationToken>());
    }
}
