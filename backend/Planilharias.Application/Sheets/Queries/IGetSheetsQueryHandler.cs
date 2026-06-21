using Planilharias.Domain.Sheets.Models;

namespace Planilharias.Application.Sheets.Queries;

public interface IGetSheetsQueryHandler
{
    Task<List<Sheet>> HandleAsync(GetSheetsByWorkbookQuery byWorkbookQuery);
}