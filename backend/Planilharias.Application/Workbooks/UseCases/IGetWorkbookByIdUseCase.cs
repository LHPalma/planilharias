using Planilharias.Application.Workbooks.DTOs.Responses;

namespace Planilharias.Application.Workbooks.UseCases;

public interface IGetWorkbookByIdUseCase
{
    Task<WorkbookResponse> ExecuteAsync(Guid id);
}