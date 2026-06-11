using Planilharias.Domain.Workbooks.Model;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Application.Workbooks.Query;

public class GetWorkbooksQueryHandler(IWorkbookRepository repository) : IGetWorkbooksQueryHandler
{
    public Task<List<Workbook>> HandleAsync(GetWorkbooksQuery query)
    {
        return repository.GetAllAsync();
    }
}