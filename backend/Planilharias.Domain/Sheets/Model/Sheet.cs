using System.ComponentModel.DataAnnotations.Schema;
using Planilharias.Domain.Workbooks.Model;

namespace Planilharias.Domain.Sheets.Model;

[Table("sheets")]
public class Sheet
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Position { get; set; }

    [Column(TypeName = "jsonb")]
    public Dictionary<string, string> Cells { get; set; } = new();

    public Guid WorkbookId { get; set; }

    public Workbook Workbook { get; set; } = null!;
}