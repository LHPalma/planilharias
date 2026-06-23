using Planilharias.Application.Abstractions;
using Planilharias.Application.Workbooks.DTOs.Responses;
using Planilharias.Application.Workbooks.Mappers;
using Planilharias.Application.Workbooks.Queries;
using Planilharias.Domain.Workbooks.Models;

namespace Planilharias.Application.Workbooks.UseCases;

public sealed class GetWorkbookByIdUseCase(
    IQueryHandler<GetWorkbookByIdQuery, Workbook> handler,
    WorkbookMapper mapper
) : IGetWorkbookByIdUseCase
{
    public async Task<WorkbookResponse> ExecuteAsync(Guid id, CancellationToken ct)
    {
        var workbook = await handler.HandleAsync(new GetWorkbookByIdQuery(id), ct);
        return mapper.ToResponse(workbook);
    }
}
