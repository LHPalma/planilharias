namespace Planilharias.Application.Sheets.DTOs.Response;

public record SheetResponse(
    Guid Id,
    string Name,
    int Position,
    Guid WorkbookId
);