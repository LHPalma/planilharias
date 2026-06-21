using Planilharias.Application.Sheets.DTOs.Responses;

namespace Planilharias.Application.Sheets.UseCases;

public interface IGetSheetsByWorkbookUseCase
{
    Task<List<SheetResponse>> ExecuteAsync(Guid workbookId);
}