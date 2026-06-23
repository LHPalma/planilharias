using Planilharias.Application.Workbooks.DTOs.Responses;

namespace Planilharias.Application.Workbooks.UseCases;

public interface IGetWorkbooksUseCase
{
    Task<List<WorkbookResponse>> ExecuteAsync(CancellationToken ct);
}
