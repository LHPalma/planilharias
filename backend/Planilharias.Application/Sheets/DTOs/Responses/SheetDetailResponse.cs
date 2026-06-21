namespace Planilharias.Application.Sheets.DTOs.Responses;

public record SheetDetailResponse(
    Guid Id,
    string Name,
    int Position,
    Guid WorkbookId,
    Dictionary<string, string> Cells
);