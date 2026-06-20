using NSubstitute;
using Planilharias.Application.Workbooks.Mappers;
using Planilharias.Application.Workbooks.Query;
using Planilharias.Application.Workbooks.UseCases;
using Planilharias.Domain.Workbooks.Model;

namespace Planilharias.Tests.Workbooks.UseCases;

public class GetWorkbookByIdUseCaseTests
{
    private readonly IGetWorkbookByIdQueryHandler _handler;
    private readonly GetWorkbookByIdUseCase _useCase;

    public GetWorkbookByIdUseCaseTests()
    {
        _handler = Substitute.For<IGetWorkbookByIdQueryHandler>();
        _useCase = new GetWorkbookByIdUseCase(_handler, new WorkbookMapper());
    }

    [Fact(DisplayName = "Busca o workbook por id e devolve a resposta mapeada")]
    public async Task ExecuteAsync_WithExistingId_ReturnsMappedResponse()
    {
        // Arrange
        var id = Guid.NewGuid();
        var workbook = Workbook.Create("Cavalos do Carlinhos");
        _handler.HandleAsync(id).Returns(workbook);

        // Act
        var result = await _useCase.ExecuteAsync(id);

        // Assert
        Assert.Equal(workbook.Id, result.Id);
        Assert.Equal(workbook.Name, result.Name);
        Assert.Equal(workbook.CreatedAt, result.CreatedAt);
        await _handler.Received(1).HandleAsync(id);
    }
}