using NSubstitute;
using Planilharias.Application.Abstractions;
using Planilharias.Application.Workbooks.Mappers;
using Planilharias.Application.Workbooks.Queries;
using Planilharias.Application.Workbooks.UseCases;
using Planilharias.Domain.Workbooks.Models;

namespace Planilharias.Tests.Workbooks.UseCases;

public class GetWorkbookByIdUseCaseTests
{
    private readonly IQueryHandler<GetWorkbookByIdQuery, Workbook> _handler;
    private readonly GetWorkbookByIdUseCase _useCase;

    public GetWorkbookByIdUseCaseTests()
    {
        _handler = Substitute.For<IQueryHandler<GetWorkbookByIdQuery, Workbook>>();
        _useCase = new GetWorkbookByIdUseCase(_handler, new WorkbookMapper());
    }

    [Fact(DisplayName = "Busca o workbook por id e devolve a resposta mapeada")]
    public async Task ExecuteAsync_WithExistingId_ReturnsMappedResponse()
    {
        // Arrange
        var id = Guid.NewGuid();
        var workbook = Workbook.Create("Cavalos do Carlinhos");
        _handler.HandleAsync(Arg.Any<GetWorkbookByIdQuery>(), Arg.Any<CancellationToken>()).Returns(workbook);

        // Act
        var result = await _useCase.ExecuteAsync(id, CancellationToken.None);

        // Assert
        Assert.Equal(workbook.Id, result.Id);
        Assert.Equal(workbook.Name, result.Name);
        Assert.Equal(workbook.CreatedAt, result.CreatedAt);
        await _handler.Received(1).HandleAsync(Arg.Is<GetWorkbookByIdQuery>(q => q.Id == id), Arg.Any<CancellationToken>());
    }
}
