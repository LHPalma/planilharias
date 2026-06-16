using Planilharias.Application.Workbooks.Command;
using Planilharias.Application.Workbooks.DTOs.Requests;
using Planilharias.Application.Workbooks.DTOs.Responses;
using Planilharias.Application.Workbooks.Mappers;

namespace Planilharias.Application.Workbooks.UseCases;

public class CreateWorkbookUseCase(
    ICreateWorkbookCommandHandler handler,
    WorkbookMapper mapper
) : ICreateWorkbookUseCase
{
    public async Task<WorkbookResponse> ExecuteAsync(CreateWorkbookRequest request)
    {
        var workbook = await handler.HandleAsync(new CreateWorkbookCommand(request.Name));
        return mapper.ToResponse(workbook);
    }
}