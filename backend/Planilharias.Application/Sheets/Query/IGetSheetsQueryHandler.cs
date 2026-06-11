using Planilharias.Domain.Sheets.Model;

namespace Planilharias.Application.Sheets.Query;

public interface IGetSheetsQueryHandler
{
    Task<List<Sheet>> HandleAsync(GetSheetsByWorkbookQuery byWorkbookQuery);
}