using Planilharias.Domain.Workbooks.Model;

namespace Planilharias.Application.Workbooks.Command;

public interface ICreateWorkbookCommandHandler
{
    Task<Workbook> HandleAsync(CreateWorkbookCommand command);
}