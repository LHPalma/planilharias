using Planilharias.Application.Abstractions;
using Planilharias.Application.Sheets.DTOs.Responses;
using Planilharias.Application.Sheets.Mappers;
using Planilharias.Application.Sheets.Queries;
using Planilharias.Domain.Sheets.Models;

namespace Planilharias.Application.Sheets.UseCases;

public class GetSheetDetailUseCase(
    IQueryHandler<GetSheetQuery, Sheet> handler,
    SheetMapper mapper
) : IGetSheetDetailUseCase
{
    public async Task<SheetDetailResponse> ExecuteAsync(Guid sheetId, CancellationToken ct)
    {
        var sheet = await handler.HandleAsync(new GetSheetQuery(sheetId), ct);
        return mapper.ToDetailResponse(sheet);
    }
}
