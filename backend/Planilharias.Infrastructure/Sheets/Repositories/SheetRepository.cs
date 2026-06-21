using Microsoft.EntityFrameworkCore;
using Planilharias.Domain.Sheets.Models;
using Planilharias.Domain.Sheets.Repositories;
using Planilharias.Infrastructure.Data;
using Planilharias.Infrastructure.Repositories;

namespace Planilharias.Infrastructure.Sheets.Repositories;

public class SheetRepository(PlanilhariasDbContext db)
    : BaseRepository<Sheet>(db), ISheetRepository
{
    public Task<List<Sheet>> FindByWorkbookIdAsync(Guid workbookId)
    {
        return Db.Sheets
            .Where(s => s.WorkbookId == workbookId)
            .ToListAsync();
    }
}