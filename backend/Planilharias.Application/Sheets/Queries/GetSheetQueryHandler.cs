using Planilharias.Domain.Sheets.Models;
using Planilharias.Domain.Sheets.Repositories;

namespace Planilharias.Application.Sheets.Queries;

public class GetSheetQueryHandler(ISheetRepository repository)
    : IGetSheetQueryHandler
{
    public async Task<Sheet> HandleAsync(GetSheetQuery query)
    {
        return await repository.GetByIdAsync(query.SheetId);
    }
}