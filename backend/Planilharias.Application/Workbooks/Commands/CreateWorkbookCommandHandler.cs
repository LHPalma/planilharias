using Planilharias.Application.Abstractions;
using Planilharias.Domain.Workbooks.Models;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Application.Workbooks.Commands;

public sealed class CreateWorkbookCommandHandler(
    IWorkbookRepository repository
) : ICommandHandler<CreateWorkbookCommand, Workbook>
{
    public async Task<Workbook> HandleAsync(CreateWorkbookCommand command, CancellationToken ct)
    {
        var workbook = Workbook.Create(command.WorkbookName);
        return await repository.AddAsync(workbook, ct);
    }
}
