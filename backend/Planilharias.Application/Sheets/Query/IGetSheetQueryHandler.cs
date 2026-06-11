using Planilharias.Domain.Sheets.Model;

namespace Planilharias.Application.Sheets.Query;

public interface IGetSheetQueryHandler
{
    Task<Sheet> HandleAsync(GetSheetQuery query);
}