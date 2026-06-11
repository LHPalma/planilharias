using Planilharias.Application.Sheets.DTOs.Response;

namespace Planilharias.Application.Sheets.UseCases;

public interface IGetSheetsByWorkbookUseCase
{
    Task<List<SheetResponse>> ExecuteAsync(Guid workbookId);
}