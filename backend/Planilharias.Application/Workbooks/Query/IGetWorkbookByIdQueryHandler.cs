using Planilharias.Domain.Workbooks.Model;

namespace Planilharias.Application.Workbooks.Query;

public interface IGetWorkbookByIdQueryHandler
{
    Task<Workbook> HandleAsync(Guid id);
}