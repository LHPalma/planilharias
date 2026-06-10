using Planilharias.Application.Workbooks;
using Planilharias.Domain.Workbooks.Model;
using Planilharias.Domain.Workbooks.Repositories;

namespace Planilharias.Infrastructure.Workbooks.Query;

public class GetWorkbooksQueryHandler(IWorkbookBaseRepository repository) : IGetWorkbooksQueryHandler
{
    public Task<List<Workbook>> HandleAsync(GetWorkbooksQuery query) =>
        repository.GetAllAsync();
}