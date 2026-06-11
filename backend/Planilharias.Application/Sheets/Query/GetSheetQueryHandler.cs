using Planilharias.Domain.Sheets.Model;
using Planilharias.Domain.Sheets.Repositories;

namespace Planilharias.Application.Sheets.Query;

public class GetSheetQueryHandler(ISheetRepository repository)
    : IGetSheetQueryHandler
{
    public async Task<Sheet> HandleAsync(GetSheetQuery query)
    {
        return await repository.GetByIdAsync(query.SheetId);
    }
}