using Planilharias.Domain.Workbooks.Models;
using Planilharias.Domain.Workbooks.Repositories;
using Planilharias.Infrastructure.Data;
using Planilharias.Infrastructure.Repositories;

namespace Planilharias.Infrastructure.Workbooks.Repositories;

public class WorkbookRepository(PlanilhariasDbContext db)
    : BaseRepository<Workbook>(db), IWorkbookRepository
{
}