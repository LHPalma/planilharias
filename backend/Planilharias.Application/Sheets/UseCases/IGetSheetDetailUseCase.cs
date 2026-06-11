using Planilharias.Application.Sheets.DTOs.Response;

namespace Planilharias.Application.Sheets.UseCases;

public interface IGetSheetDetailUseCase
{
    Task<SheetDetailResponse> ExecuteAsync(Guid sheetId);
}