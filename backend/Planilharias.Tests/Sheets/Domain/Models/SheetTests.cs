using Planilharias.Domain.Sheets.Exceptions;
using Planilharias.Domain.Sheets.Models;

namespace Planilharias.Tests.Sheets.Domain.Models;

public class SheetTests
{
    private static readonly Guid WorkbookId = Guid.NewGuid();

    [Theory(DisplayName = "Não cria sheet com nome nulo, vazio ou em branco")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithInvalidName_InvalidSheetNameException(string? invalidName)
    {
        // Assert
        Assert.Throws<InvalidSheetNameException>(() => Sheet.Create(invalidName!, WorkbookId, 0));
    }

    [Fact(DisplayName = "Não cria sheet com posição negativa")]
    public void Create_WithNegativePosition_InvalidSheetPositionException()
    {
        // Assert
        Assert.Throws<InvalidSheetPositionException>(() => Sheet.Create("Página 1", WorkbookId, -1));
    }

    [Fact(DisplayName = "Aplica Trim no nome da sheet")]
    public void Create_WithSurroundingWhitespace_TrimsName()
    {
        // Act
        var sheet = Sheet.Create("  Página 1  ", WorkbookId, 0);

        // Assert
        Assert.Equal("Página 1", sheet.Name);
    }

    [Fact(DisplayName = "Cria sheet com nome exatamente no limite")]
    public void Create_WithNameAtMaxLength_Succeeds()
    {
        // Arrange
        var atLimit = new string('A', Sheet.NameMaxLength);

        // Act
        var sheet = Sheet.Create(atLimit, WorkbookId, 0);

        // Assert
        Assert.Equal(atLimit, sheet.Name);
    }

    [Fact(DisplayName = "Não cria sheet com nome maior que o limite")]
    public void Create_WithNameExceedingMaxLength_SheetNameTooLongException()
    {
        // Arrange
        var tooLong = new string('A', Sheet.NameMaxLength + 1);

        // Assert
        Assert.Throws<SheetNameTooLongException>(() => Sheet.Create(tooLong, WorkbookId, 0));
    }

    [Fact(DisplayName = "Cria sheet associada ao workbook, com posição e células vazias")]
    public void Create_WithValidData_SetsWorkbookPositionAndEmptyCells()
    {
        // Act
        var sheet = Sheet.Create("Página 1", WorkbookId, 2);

        // Assert
        Assert.NotEqual(Guid.Empty, sheet.Id);
        Assert.Equal(WorkbookId, sheet.WorkbookId);
        Assert.Equal(2, sheet.Position);
        Assert.Empty(sheet.Cells);
    }
}