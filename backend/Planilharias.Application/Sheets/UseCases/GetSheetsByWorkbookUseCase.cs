using Planilharias.Application.Sheets.DTOs.Responses;
using Planilharias.Application.Sheets.Mappers;
using Planilharias.Application.Sheets.Queries;

namespace Planilharias.Application.Sheets.UseCases;

public class GetSheetsByWorkbookUseCase(
    IGetSheetsQueryHandler handler,
    SheetMapper mapper
) : IGetSheetsByWorkbookUseCase
{
    public async Task<List<SheetResponse>> ExecuteAsync(Guid workbookId)
    {
        var sheets = await handler.HandleAsync(new GetSheetsByWorkbookQuery(workbookId));
        return sheets.Select(mapper.ToResponse).ToList();
    }
}