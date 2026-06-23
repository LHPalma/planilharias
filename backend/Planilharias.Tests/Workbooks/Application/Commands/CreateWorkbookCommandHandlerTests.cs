using NSubstitute;
using Planilharias.Application.Workbooks.Commands;
using Planilharias.Domain.Workbooks.Models;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Tests.Workbooks.Application.Commands;

public class CreateWorkbookCommandHandlerTests
{
    private readonly CreateWorkbookCommandHandler _handler;
    private readonly IWorkbookRepository _repository;

    public CreateWorkbookCommandHandlerTests()
    {
        _repository = Substitute.For<IWorkbookRepository>();
        _repository.AddAsync(Arg.Any<Workbook>(), Arg.Any<CancellationToken>())
            .Returns(call => call.Arg<Workbook>());

        _handler = new CreateWorkbookCommandHandler(_repository);
    }

    [Fact(DisplayName = "Persiste o workbook através do repositório")]
    public async Task HandleAsync_WithValidName_PersistsWorkbook()
    {
        // Arrange
        const string workbookName = "Cavalos do Carlinhos";
        var command = new CreateWorkbookCommand(workbookName);

        // Act
        var result = await _handler.HandleAsync(command, CancellationToken.None);

        // Assert
        Assert.Equal(workbookName, result.Name);
        await _repository.Received(1)
            .AddAsync(Arg.Is<Workbook>(w => w.Name == workbookName), Arg.Any<CancellationToken>());
    }
}
