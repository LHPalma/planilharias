using Planilharias.Domain.Workbooks.Exceptions;
using Planilharias.Domain.Workbooks.Model;

namespace Planilharias.Tests.Workbooks.Domain.Model;

public class WorkbookTests
{
    [Theory(DisplayName = "Não cria workbook com nome nulo, vazio ou em branco")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithInvalidName_InvalidWorkbookNameException(string? invalidName)
    {
        Assert.Throws<InvalidWorkbookNameException>(() => Workbook.Create(invalidName!));
    }

    [Fact(DisplayName = "Aplica Trim no nome do workbook")]
    public void Create_WithSurroundingWhitespace_TrimsName()
    {
        // Act
        var workbook = Workbook.Create("  Nome com espaços em volta  ");

        // Assert
        Assert.Equal("Nome com espaços em volta", workbook.Name);
    }

    [Fact(DisplayName = "Cria workbook com nome exatamente no limite")]
    public void Create_WithNameAtMaxLength_Succeeds()
    {
        // Arrange
        var atLimit = new string('A', Workbook.NameMaxLength);

        // Act
        var workbook = Workbook.Create(atLimit);

        // Assert
        Assert.Equal(atLimit, workbook.Name);
    }

    [Fact(DisplayName = "Não cria workbook com nome maior que o limite")]
    public void Create_WithNameExceedingMaxLength_WorkbookNameTooLongException()
    {
        // Arrange
        var tooLong = new string('A', Workbook.NameMaxLength + 1);

        // Assert
        Assert.Throws<WorkbookNameTooLongException>(() => Workbook.Create(tooLong));
    }
}