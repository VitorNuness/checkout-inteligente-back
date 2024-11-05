using App.DTOs;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(
            ReportService reportService
        )
        {
            this._reportService = reportService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportDTO?>>> GetAll()
        {
            return Ok(await this._reportService.GetReports());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await this._reportService.RemoveReport(id);

            return Ok();
        }
    }
}
