namespace Planilharias.Application.Workbooks.DTOs.Response;

public record WorkbookResponse(
    Guid Id,
    string Name,
    DateTime CreatedAt
);