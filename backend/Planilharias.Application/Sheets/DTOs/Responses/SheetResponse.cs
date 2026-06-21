namespace Planilharias.Application.Sheets.DTOs.Responses;

public record SheetResponse(
    Guid Id,
    string Name,
    int Position,
    Guid WorkbookId
);