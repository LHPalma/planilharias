using Planilharias.Domain.Exceptions;

namespace Planilharias.Domain.Workbooks.Exceptions;

public sealed class InvalidWorkbookNameException()
    : BaseDomainException(
        "workbook.name.required",
        "Workbook name cannot be null, empty or whitespace.")
{
}