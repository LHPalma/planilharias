using Planilharias.Domain.Repositories;
using Planilharias.Domain.Sheets.Models;

namespace Planilharias.Domain.Sheets.Repositories;

public interface ISheetRepository : IBaseRepository<Sheet>
{
    Task<List<Sheet>> FindByWorkbookIdAsync(Guid workbookId);
}