using Planilharias.Application.Abstractions;
using Planilharias.Application.Workbooks.DTOs.Responses;
using Planilharias.Application.Workbooks.Mappers;
using Planilharias.Application.Workbooks.Queries;
using Planilharias.Domain.Workbooks.Models;

namespace Planilharias.Application.Workbooks.UseCases;

public class GetWorkbooksUseCase(
    IQueryHandler<GetWorkbooksQuery, List<Workbook>> handler,
    WorkbookMapper mapper
) : IGetWorkbooksUseCase
{
    public async Task<List<WorkbookResponse>> ExecuteAsync()
    {
        var workbooks = await handler.HandleAsync(new GetWorkbooksQuery());
        return workbooks.Select(mapper.ToResponse).ToList();
    }
}
