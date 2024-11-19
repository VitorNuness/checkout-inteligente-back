namespace Presentation.Controllers;

using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;


[Route("api/reports")]
[ApiController]
public class ReportController(
    IReportService reportService
    ) : ControllerBase
{
    private readonly IReportService _reportService = reportService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReportDTO?>>> GetAll() => this.Ok(await this._reportService.GetReports());

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(int id)
    {
        await this._reportService.RemoveReport(id);

        return this.Ok();
    }
}
