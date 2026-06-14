using Planilharias.Application.Workbooks.DTOs.Response;

namespace Planilharias.Application.Workbooks.UseCases;

public interface ICreateWorkbookUseCase
{
    Task<WorkbookResponse> ExecuteAsync(string workbookName);
}