using Microsoft.AspNetCore.Mvc;
using Planilharias.Application.Workbooks.UseCases;

namespace Planilharias.Api.Workbooks;

[ApiController]
[Route("workbooks")]
public class WorkbooksController(
    IGetWorkbooksUseCase getWorkbooksUseCase
) : ControllerBase
{
    #region GET

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await getWorkbooksUseCase.ExecuteAsync());
    }

    #endregion
}