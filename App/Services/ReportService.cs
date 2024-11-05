using System;
using App.DTOs;
using App.Repositories;

namespace App.Services;

public class ReportService
{
    private readonly ReportRepository _reportRepository;
    private readonly IWebHostEnvironment _environment;

    public ReportService(
        ReportRepository reportRepository,
        IWebHostEnvironment environment
    )
    {
        _reportRepository = reportRepository;
        _environment = environment;
    }

    public async Task<IEnumerable<ReportDTO?>> GetReports()
    {
        return await this._reportRepository.GetAll();
    }

    public async Task CreateReport(ReportDTO reportDTO)
    {
        await this._reportRepository.Store(reportDTO);
    }

    public async Task RemoveReport(int id)
    {
        ReportDTO report = await this._reportRepository.FindOrFail(id);
        
        string filePath = Path.Combine(this._environment.WebRootPath, "files", "exports", "csv", report.Name!);
        File.Delete(filePath);

        await this._reportRepository.Destroy(id);
    }
}
