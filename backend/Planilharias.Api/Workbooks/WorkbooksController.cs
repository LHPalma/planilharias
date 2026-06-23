using Microsoft.AspNetCore.Mvc;
using Planilharias.Application.Workbooks.DTOs.Requests;
using Planilharias.Application.Workbooks.UseCases;

namespace Planilharias.Api.Workbooks;

[ApiController]
[Route("workbooks")]
public class WorkbooksController(
    IGetWorkbooksUseCase getWorkbooksUseCase,
    ICreateWorkbookUseCase createWorkbookUseCase,
    IGetWorkbookByIdUseCase getWorkbookByIdUseCase
) : ControllerBase
{
    #region GET

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        return Ok(await getWorkbookByIdUseCase.ExecuteAsync(id, ct));
    }


    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await getWorkbooksUseCase.ExecuteAsync(ct));
    }

    #endregion

    #region POST

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorkbookRequest request, CancellationToken ct)
    {
        var workbook = await createWorkbookUseCase.ExecuteAsync(request, ct);
        return CreatedAtAction(
            nameof(GetById),
            new { id = workbook.Id },
            workbook
        );
    }

    #endregion POST
}
