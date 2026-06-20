using Planilharias.Domain.Exceptions;

namespace Planilharias.Domain.Sheets.Exceptions;

public sealed class SheetNameTooLongException(int nameMaxLength)
    : BaseDomainException(
        "sheet.name.tooLong",
        $"Sheet name cannot be longer than {nameMaxLength} characters.")
{
}