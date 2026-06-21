using Planilharias.Domain.Workbooks.Models;

namespace Planilharias.Application.Workbooks.Queries;

public interface IGetWorkbookByIdQueryHandler
{
    Task<Workbook> HandleAsync(Guid id);
}