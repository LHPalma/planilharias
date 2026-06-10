using System.ComponentModel.DataAnnotations.Schema;
using Planilharias.Domain.Sheets.Model;

namespace Planilharias.Domain.Workbooks.Model;

[Table("workbooks")]
public class Workbook
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Sheet> Sheets { get; set; } = [];
}