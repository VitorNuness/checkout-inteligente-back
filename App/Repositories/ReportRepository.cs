using App.DTOs;
using App.Models;
using App.Repositories.Database;

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
