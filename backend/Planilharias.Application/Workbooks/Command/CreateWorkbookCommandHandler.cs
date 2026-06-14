using Planilharias.Domain.Workbooks.Model;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Application.Workbooks.Command;

public class CreateWorkbookCommandHandler(
    IWorkbookRepository repository
) : ICreateWorkbookCommandHandler
{
    public async Task<Workbook> HandleAsync(CreateWorkbookCommand command)
    {
        var workbook = Workbook.Create(command.WorkbookName);
        return await repository.AddAsync(workbook);
    }
}