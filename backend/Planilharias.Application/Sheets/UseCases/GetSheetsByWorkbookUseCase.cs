using Planilharias.Application.Abstractions;
using Planilharias.Application.Sheets.DTOs.Responses;
using Planilharias.Application.Sheets.Mappers;
using Planilharias.Application.Sheets.Queries;
using Planilharias.Domain.Sheets.Models;

namespace Planilharias.Application.Sheets.UseCases;

public class GetSheetsByWorkbookUseCase(
    IQueryHandler<GetSheetsByWorkbookQuery, List<Sheet>> handler,
    SheetMapper mapper
) : IGetSheetsByWorkbookUseCase
{
    public async Task<List<SheetResponse>> ExecuteAsync(Guid workbookId, CancellationToken ct)
    {
        var sheets = await handler.HandleAsync(new GetSheetsByWorkbookQuery(workbookId), ct);
        return sheets.Select(mapper.ToResponse).ToList();
    }
}
