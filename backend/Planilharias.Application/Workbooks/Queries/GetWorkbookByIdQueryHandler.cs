using Planilharias.Application.Abstractions;
using Planilharias.Domain.Workbooks.Models;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Application.Workbooks.Queries;

public sealed class GetWorkbookByIdQueryHandler(
    IWorkbookRepository repository
) : IQueryHandler<GetWorkbookByIdQuery, Workbook>
{
    public Task<Workbook> HandleAsync(GetWorkbookByIdQuery query, CancellationToken ct)
    {
        return repository.GetByIdAsync(query.Id, ct);
    }
}
