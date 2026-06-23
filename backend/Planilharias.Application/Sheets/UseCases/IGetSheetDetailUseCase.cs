using Planilharias.Application.Sheets.DTOs.Responses;

namespace Planilharias.Application.Sheets.UseCases;

public interface IGetSheetDetailUseCase
{
    Task<SheetDetailResponse> ExecuteAsync(Guid sheetId, CancellationToken ct);
}
