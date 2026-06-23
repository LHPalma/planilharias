using NSubstitute;
using Planilharias.Application.Abstractions;
using Planilharias.Application.Workbooks.Commands;
using Planilharias.Application.Workbooks.DTOs.Requests;
using Planilharias.Application.Workbooks.Mappers;
using Planilharias.Application.Workbooks.UseCases;
using Planilharias.Domain.Workbooks.Models;

namespace Planilharias.Tests.Workbooks.UseCases;

public class CreateWorkbookUseCaseTests
{
    private readonly ICommandHandler<CreateWorkbookCommand, Workbook> _handler;
    private readonly CreateWorkbookUseCase _useCaseTests;

    public CreateWorkbookUseCaseTests()
    {
        _handler = Substitute.For<ICommandHandler<CreateWorkbookCommand, Workbook>>();
        _useCaseTests = new CreateWorkbookUseCase(_handler, new WorkbookMapper());
    }


    [Fact(DisplayName = "Cria o workbook e devolve a resposta mapeada")]
    public async Task ExecuteAsync_WithValidName_ReturnsMappedResponse()
    {
        // Arrange
        const string workbookName = "Cavalos do Carlinhos";
        var request = new CreateWorkbookRequest(workbookName);
        var created = Workbook.Create(workbookName);
        _handler.HandleAsync(Arg.Any<CreateWorkbookCommand>(), Arg.Any<CancellationToken>())
            .Returns(created);

        // Act
        var result = await _useCaseTests.ExecuteAsync(request, CancellationToken.None);

        // Assert
        Assert.Equal(created.Id, result.Id);
        Assert.Equal(created.Name, result.Name);
        await _handler.Received(1)
            .HandleAsync(Arg.Is<CreateWorkbookCommand>(c => c.WorkbookName == request.Name), Arg.Any<CancellationToken>());
    }
}
