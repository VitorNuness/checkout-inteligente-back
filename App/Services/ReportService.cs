using System;
using App.DTOs;
using App.Repositories;

namespace App.Services;

public class ReportService
{
    private readonly ReportRepository _reportRepository;

    public ReportService(
        ReportRepository reportRepository
    )
    {
        _reportRepository = reportRepository;
    }

    public async Task<IEnumerable<ReportDTO?>> GetReports()
    {
        return await this._reportRepository.GetAll();
    }

    public async Task CreateReport(ReportDTO reportDTO)
    {
        await this._reportRepository.Store(reportDTO);
    }
}
