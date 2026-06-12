using Planilharias.Application.Sheets.DTOs.Response;
using Planilharias.Application.Sheets.Mappers;
using Planilharias.Application.Sheets.Query;

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