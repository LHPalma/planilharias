using Planilharias.Application.Abstractions;
using Planilharias.Application.Workbooks.Commands;
using Planilharias.Application.Workbooks.DTOs.Requests;
using Planilharias.Application.Workbooks.DTOs.Responses;
using Planilharias.Application.Workbooks.Mappers;
using Planilharias.Domain.Workbooks.Models;

namespace Planilharias.Application.Workbooks.UseCases;

public class CreateWorkbookUseCase(
    ICommandHandler<CreateWorkbookCommand, Workbook> handler,
    WorkbookMapper mapper
) : ICreateWorkbookUseCase
{
    public async Task<WorkbookResponse> ExecuteAsync(CreateWorkbookRequest request, CancellationToken ct)
    {
        var workbook = await handler.HandleAsync(new CreateWorkbookCommand(request.Name), ct);
        return mapper.ToResponse(workbook);
    }
}
