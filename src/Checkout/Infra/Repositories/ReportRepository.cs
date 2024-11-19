namespace Infra.Repositories;

using Infra.Repositories.Database;
using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

public class ReportRepository : IReportRepository
{
    private readonly CheckoutDbContext _dbContext;

    public ReportRepository(CheckoutDbContext dbContext) => this._dbContext = dbContext;

    public async Task Destroy(int id)
    {
        var report = await this._dbContext.Reports.FindAsync(id);
        if (report is null)
        {
            return;
        }

        this._dbContext.Reports.Remove(report);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task<ReportDTO> FindOrFail(int id)
    {
        var report = await this._dbContext.Reports.FindAsync(id) ?? throw new Exception("Report not exist.");

        return new ReportDTO(
            id: report.Id,
            name: report.Name,
            url: report.Url,
            reference: report.Reference,
            createdAt: report.CreatedAt.ToShortDateString()
        );
    }

    public async Task<IEnumerable<ReportDTO?>> GetAll()
    {
        var reportsFromDbContext = await this._dbContext.Reports.ToListAsync();
        return reportsFromDbContext.Select(
            r => new ReportDTO(
                r.Id,
                r.Name,
                r.Url,
                r.Reference,
                r.CreatedAt.ToShortDateString()
            ));
    }

    public async Task<Report> Store(ReportDTO reportDTO)
    {

        var report = await this.WhereName(reportDTO.Name!);

        if (report is null)
        {
            report = new(
                name: reportDTO.Name!,
                url: reportDTO.Url!,
                reference: reportDTO.Reference!
            );
            this._dbContext.Add(report);
            await this._dbContext.SaveChangesAsync();
        }

        return report;
    }

    public async Task<Report?> WhereName(string name) => await this._dbContext.Reports.Where(r => r.Name == name).FirstOrDefaultAsync();
}
