using Planilharias.Domain.Workbooks.Models;

namespace Planilharias.Application.Workbooks.Commands;

public interface ICreateWorkbookCommandHandler
{
    Task<Workbook> HandleAsync(CreateWorkbookCommand command);
}