using Planilharias.Application.Workbooks.DTOs.Response;

namespace Planilharias.Application.Workbooks.UseCases;

public interface IGetWorkbooksUseCase
{
    Task<List<WorkbookResponse>> ExecuteAsync();
}