using App.DTOs;
using App.Models;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories;

public class ReportRepository
{
    private readonly CheckoutDbContext _dbContext;

    public ReportRepository(
        CheckoutDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public async Task Destroy(int id)
    {
        Report? report = await this._dbContext.Reports.FindAsync(id);
        if (report is null)
        {
            return;
        }

        this._dbContext.Reports.Remove(report);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task<ReportDTO> FindOrFail(int id)
    {
        var report = await this._dbContext.Reports.FindAsync(id);

        if (report is null)
        {
            throw new Exception("Report not exist.");
        }

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
        Report report = new(
            reportDTO.Name!,
            reportDTO.Url!,
            reportDTO.Reference!
        );
        
        _dbContext.Add(report);
        await _dbContext.SaveChangesAsync();

        return report;
    }
}
