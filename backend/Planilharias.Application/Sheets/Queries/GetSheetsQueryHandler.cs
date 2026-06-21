using Planilharias.Domain.Sheets.Models;
using Planilharias.Domain.Sheets.Repositories;

namespace Planilharias.Application.Sheets.Queries;

public class GetSheetsQueryHandler(ISheetRepository repository)
    : IGetSheetsQueryHandler
{
    public async Task<List<Sheet>> HandleAsync(GetSheetsByWorkbookQuery byWorkbookQuery)
    {
        return await repository.FindByWorkbookIdAsync(byWorkbookQuery.WorkbookId);
    }
}