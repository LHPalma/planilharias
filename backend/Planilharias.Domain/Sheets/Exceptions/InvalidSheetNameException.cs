using Planilharias.Domain.Exceptions;

namespace Planilharias.Domain.Sheets.Exceptions;

public sealed class InvalidSheetNameException()
    : BaseDomainException(
        "sheet.name.required",
        "Sheet name cannot be null, empty or whitespace.")
{
}