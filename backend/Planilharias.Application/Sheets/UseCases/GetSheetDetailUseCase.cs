using Planilharias.Application.Sheets.DTOs.Response;
using Planilharias.Application.Sheets.Mappers;
using Planilharias.Application.Sheets.Query;

namespace Planilharias.Application.Sheets.UseCases;

public class GetSheetDetailUseCase(
    IGetSheetQueryHandler handler,
    SheetMapper mapper
) : IGetSheetDetailUseCase
{
    public async Task<SheetDetailResponse> ExecuteAsync(Guid sheetId)
    {
        var sheet = await handler.HandleAsync(new GetSheetQuery(sheetId));
        return mapper.ToDetailResponse(sheet);
    }
}