namespace Planilharias.Application.Workbooks.DTOs.Responses;

public record WorkbookResponse(
    Guid Id,
    string Name,
    DateTime CreatedAt
);