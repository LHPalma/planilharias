using Planilharias.Application.Abstractions;
using Planilharias.Domain.Workbooks.Models;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Application.Workbooks.Queries;

public sealed class GetWorkbooksQueryHandler(IWorkbookRepository repository)
    : IQueryHandler<GetWorkbooksQuery, List<Workbook>>
{
    public Task<List<Workbook>> HandleAsync(GetWorkbooksQuery query)
    {
        return repository.GetAllAsync();
    }
}
