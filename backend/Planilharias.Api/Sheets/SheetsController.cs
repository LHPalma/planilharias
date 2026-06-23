using Microsoft.AspNetCore.Mvc;
using Planilharias.Application.Sheets.UseCases;

namespace Planilharias.Api.Sheets;

[ApiController]
public class SheetsController(
    IGetSheetsByWorkbookUseCase getSheetsByWorkbookUseCase,
    IGetSheetDetailUseCase getSheetDetailUseCase
) : ControllerBase
{
    #region GET

    [HttpGet("workbooks/{workbookId:guid}/sheets")]
    public async Task<IActionResult> GetByWorkbook(Guid workbookId, CancellationToken ct)
    {
        return Ok(await getSheetsByWorkbookUseCase.ExecuteAsync(workbookId, ct));
    }

    [HttpGet("sheets/{sheetId:guid}")]
    public async Task<IActionResult> GetSheet(Guid sheetId, CancellationToken ct)
    {
        return Ok(await getSheetDetailUseCase.ExecuteAsync(sheetId, ct));
    }

    #endregion
}
