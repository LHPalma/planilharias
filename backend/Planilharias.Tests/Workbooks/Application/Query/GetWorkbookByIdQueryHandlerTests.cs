using NSubstitute;
using Planilharias.Application.Workbooks.Query;
using Planilharias.Domain.Workbooks.Model;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Tests.Workbooks.Application.Query;

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
        _repository.GetByIdAsync(id).Returns(workbook);

        // Act
        var result = await _handler.HandleAsync(id);

        // Assert
        Assert.Same(workbook, result);
        await _repository.Received(1).GetByIdAsync(id);
    }
}