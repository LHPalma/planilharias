using Planilharias.Domain.Workbooks.Exceptions;
using Planilharias.Domain.Workbooks.Model;

namespace Planilharias.Tests.Workbooks.Domain.Model;

public class WorkbookTests
{
    [Theory(DisplayName = "Não cria workbook com nome nulo, vazio ou em branco")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithInvalidName_ThrowsArgumentException(string? invalidName)
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
}