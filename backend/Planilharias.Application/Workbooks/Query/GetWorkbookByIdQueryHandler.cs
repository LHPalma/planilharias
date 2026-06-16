using Planilharias.Domain.Workbooks.Model;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Application.Workbooks.Query;

public class GetWorkbookByIdQueryHandler(
    IWorkbookRepository repository
) : IGetWorkbookByIdQueryHandler
{
    public Task<Workbook> HandleAsync(Guid id)
    {
        return repository.GetByIdAsync(id);
    }
}