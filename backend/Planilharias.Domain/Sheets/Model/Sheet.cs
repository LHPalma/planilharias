using System.ComponentModel.DataAnnotations.Schema;
using Planilharias.Domain.Sheets.Exceptions;
using Planilharias.Domain.Workbooks.Model;

namespace Planilharias.Domain.Sheets.Model;

[Table("sheets")]
public class Sheet
{
    public const int NameMaxLength = 50;

    private Sheet()
    {
    }

    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Position { get; set; }

    [Column(TypeName = "jsonb")]
    public Dictionary<string, string> Cells { get; set; } = new();

    public Guid WorkbookId { get; set; }

    public Workbook Workbook { get; set; } = null!;

    public static Sheet Create(
        string name,
        Guid workbookId,
        int position)
    {
        name = NormalizeName(name);
        ValidateName(name);
        ValidatePosition(position);

        return new Sheet
        {
            Id = Guid.NewGuid(),
            Name = name,
            WorkbookId = workbookId,
            Position = position,
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
            throw new InvalidSheetNameException();
        }

        if (name.Length > NameMaxLength)
        {
            throw new SheetNameTooLongException(NameMaxLength);
        }
    }

    private static void ValidatePosition(int position)
    {
        if (position < 0)
        {
            throw new InvalidSheetPositionException();
        }
    }
}