using Planilharias.Application.Workbooks.DTOs.Responses;
using Planilharias.Application.Workbooks.Mappers;
using Planilharias.Application.Workbooks.Query;

namespace Planilharias.Application.Workbooks.UseCases;

public class GetWorkbookByIdUseCase(
    IGetWorkbookByIdQueryHandler handler,
    WorkbookMapper mapper
) : IGetWorkbookByIdUseCase
{
    public async Task<WorkbookResponse> ExecuteAsync(Guid id)
    {
        var workbook = await handler.HandleAsync(id);
        return mapper.ToResponse(workbook);
    }
}