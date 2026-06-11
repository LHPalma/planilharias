namespace Planilharias.Application.Sheets.DTOs.Response;

public record SheetDetailResponse(
    Guid Id,
    string Name,
    int Position,
    Guid WorkbookId,
    Dictionary<string, string> Cells
);