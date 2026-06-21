using Planilharias.Domain.Sheets.Models;

namespace Planilharias.Application.Sheets.Queries;

public interface IGetSheetQueryHandler
{
    Task<Sheet> HandleAsync(GetSheetQuery query);
}