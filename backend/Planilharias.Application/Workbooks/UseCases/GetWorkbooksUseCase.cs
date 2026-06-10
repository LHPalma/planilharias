using Planilharias.Application.Workbooks.DTOs.Response;
using Planilharias.Application.Workbooks.Mappers;

namespace Planilharias.Application.Workbooks.UseCases;

public class GetWorkbooksUseCase(
    IGetWorkbooksQueryHandler handler,
    WorkbookMapper mapper
) : IGetWorkbooksUseCase
{
    public async Task<List<WorkbookResponse>> ExecuteAsync()
    {
        var workbooks = await handler.HandleAsync(new GetWorkbooksQuery());
        return workbooks.Select(mapper.ToResponse).ToList();
    }
}