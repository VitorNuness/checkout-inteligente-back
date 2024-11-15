namespace Core.Repositories;

using Core.DTOs;
using Core.Models;

public interface IReportRepository
{
    public Task Destroy(int id);

    public Task<ReportDTO> FindOrFail(int id);

    public Task<IEnumerable<ReportDTO?>> GetAll();

    public Task<Report> Store(ReportDTO reportDTO);

    public Task<Report?> WhereName(string name);
}
