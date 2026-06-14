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
}