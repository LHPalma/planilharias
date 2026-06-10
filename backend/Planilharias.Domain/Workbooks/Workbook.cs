using Planilharias.Domain.Sheets;

namespace Planilharias.Domain.Workbooks;

public class Workbook
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Sheet> sheets { get; set; } = [];
}