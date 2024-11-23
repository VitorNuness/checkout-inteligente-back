namespace Core.Services;

using Core.DTOs;

public interface IReportService
{
    public Task<IEnumerable<ReportDTO?>> GetReports();

    public Task CreateReport(ReportDTO reportDTO);

    public Task RemoveReport(int id);
}
