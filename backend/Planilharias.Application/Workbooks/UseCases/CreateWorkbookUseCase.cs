using Planilharias.Application.Workbooks.Command;
using Planilharias.Application.Workbooks.DTOs.Response;
using Planilharias.Application.Workbooks.Mappers;

namespace Planilharias.Application.Workbooks.UseCases;

public class CreateWorkbookUseCase(
    ICreateWorkbookCommandHandler handler,
    WorkbookMapper mapper
) : ICreateWorkbookUseCase
{
    public async Task<WorkbookResponse> ExecuteAsync(string workbookName)
    {
        var workbook = await handler.HandleAsync(new CreateWorkbookCommand(workbookName));
        return mapper.ToResponse(workbook);
    }
}