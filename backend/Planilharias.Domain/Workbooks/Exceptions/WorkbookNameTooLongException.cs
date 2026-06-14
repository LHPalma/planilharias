using Planilharias.Domain.Exceptions;

namespace Planilharias.Domain.Workbooks.Exceptions;

public sealed class WorkbookNameTooLongException(int nameMaxLength)
    : BaseDomainException(
        "workbook.name.tooLong",
        $"Workbook name cannot be longer than {nameMaxLength} characters.")
{
}