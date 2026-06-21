using Planilharias.Domain.Workbooks.Models;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Application.Workbooks.Queries;

public class GetWorkbookByIdQueryHandler(
    IWorkbookRepository repository
) : IGetWorkbookByIdQueryHandler
{
    public Task<Workbook> HandleAsync(Guid id)
    {
        return repository.GetByIdAsync(id);
    }
}