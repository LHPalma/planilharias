using Planilharias.Domain.Workbooks.Models;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Application.Workbooks.Queries;

public class GetWorkbooksQueryHandler(IWorkbookRepository repository) : IGetWorkbooksQueryHandler
{
    public Task<List<Workbook>> HandleAsync(GetWorkbooksQuery query)
    {
        return repository.GetAllAsync();
    }
}