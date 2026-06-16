using Planilharias.Application.Workbooks.DTOs.Requests;
using Planilharias.Application.Workbooks.DTOs.Responses;

namespace Planilharias.Application.Workbooks.UseCases;

public interface ICreateWorkbookUseCase
{
    Task<WorkbookResponse> ExecuteAsync(CreateWorkbookRequest request);
}