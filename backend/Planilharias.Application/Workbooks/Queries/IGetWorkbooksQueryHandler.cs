using Planilharias.Domain.Workbooks.Models;

namespace Planilharias.Application.Workbooks;

public record GetWorkbooksQuery;

public interface IGetWorkbooksQueryHandler
{
    Task<List<Workbook>> HandleAsync(GetWorkbooksQuery query);
}