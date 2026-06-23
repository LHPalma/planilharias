using Planilharias.Application.Abstractions;
using Planilharias.Domain.Sheets.Models;
using Planilharias.Domain.Sheets.Repositories;

namespace Planilharias.Application.Sheets.Queries;

public sealed class GetSheetQueryHandler(ISheetRepository repository)
    : IQueryHandler<GetSheetQuery, Sheet>
{
    public async Task<Sheet> HandleAsync(GetSheetQuery query)
    {
        return await repository.GetByIdAsync(query.SheetId);
    }
}
