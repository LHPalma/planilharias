using System.ComponentModel.DataAnnotations.Schema;
using Planilharias.Domain.Sheets.Model;
using Planilharias.Domain.Workbooks.Exceptions;

namespace Planilharias.Domain.Workbooks.Model;

[Table("workbooks")]
public class Workbook
{
    private Workbook()
    {
    }

    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Sheet> Sheets { get; set; } = [];


    public static Workbook Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidWorkbookNameException();
        }

        name = name.Trim();

        return new Workbook
        {
            Id = Guid.NewGuid(),
            Name = name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }
}