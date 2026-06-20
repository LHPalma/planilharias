using Planilharias.Domain.Exceptions;

namespace Planilharias.Domain.Sheets.Exceptions;

public sealed class InvalidSheetPositionException()
    : BaseDomainException(
        "sheet.position.invalid",
        "Sheet position must be greater than or equal to zero.")
{
}