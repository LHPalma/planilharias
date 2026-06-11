using Planilharias.Domain.Repositories;
using Planilharias.Domain.Sheets.Model;

namespace Planilharias.Domain.Sheets.Repositories;

public interface ISheetRepository : IBaseRepository<Sheet>
{
    Task<List<Sheet>> FindByWorkbookIdAsync(Guid workbookId);
}