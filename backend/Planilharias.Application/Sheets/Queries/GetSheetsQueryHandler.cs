using Planilharias.Application.Abstractions;
using Planilharias.Domain.Sheets.Models;
using Planilharias.Domain.Sheets.Repositories;

namespace Planilharias.Application.Sheets.Queries;

public sealed class GetSheetsQueryHandler(ISheetRepository repository)
    : IQueryHandler<GetSheetsByWorkbookQuery, List<Sheet>>
{
    public async Task<List<Sheet>> HandleAsync(GetSheetsByWorkbookQuery query, CancellationToken ct)
    {
        return await repository.FindByWorkbookIdAsync(query.WorkbookId, ct);
    }
}
