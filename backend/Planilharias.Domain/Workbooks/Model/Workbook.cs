using System.ComponentModel.DataAnnotations.Schema;
using Planilharias.Domain.Sheets.Model;
using Planilharias.Domain.Workbooks.Exceptions;

namespace Planilharias.Domain.Workbooks.Model;

[Table("workbooks")]
public class Workbook
{
    public const int NameMaxLength = 100;

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
        name = NormalizeName(name);
        ValidateName(name);

        return new Workbook
        {
            Id = Guid.NewGuid(),
            Name = name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }

    private static string NormalizeName(string name)
    {
        return name?.Trim() ?? string.Empty;
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidWorkbookNameException();
        }

        if (name.Length > NameMaxLength)
        {
            throw new WorkbookNameTooLongException(NameMaxLength);
        }
    }
}