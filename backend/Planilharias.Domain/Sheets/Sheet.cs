using Planilharias.Domain.Workbooks;

namespace Planilharias.Domain.Sheets;

public class Sheet
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Position { get; set; }

    public Dictionary<string, string> Cells { get; set; } = new();

    public Workbook Workbook { get; set; } = null!;
}