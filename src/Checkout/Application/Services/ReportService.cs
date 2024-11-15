namespace Application.Services;

using Core.DTOs;
using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Hosting;

public class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;
    private readonly IWebHostEnvironment _environment;

    public ReportService(
        IReportRepository reportRepository,
        IWebHostEnvironment environment
    )
    {
        this._reportRepository = reportRepository;
        this._environment = environment;
    }

    public async Task<IEnumerable<ReportDTO?>> GetReports() => await this._reportRepository.GetAll();

    public async Task CreateReport(ReportDTO reportDTO) => await this._reportRepository.Store(reportDTO);

    public async Task RemoveReport(int id)
    {
        var report = await this._reportRepository.FindOrFail(id);
        var filePath = Path.Combine(this._environment.WebRootPath, "files", "exports", "csv", report.Name!);
        File.Delete(filePath);

        await this._reportRepository.Destroy(id);
    }
}
