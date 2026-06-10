using Planilharias.Domain.Workbooks.Model;

namespace Planilharias.Application.Workbooks;

public record GetWorkbooksQuery();

public interface IGetWorkbooksQueryHandler
{
    Task<List<Workbook>> HandleAsync(GetWorkbooksQuery query);
}