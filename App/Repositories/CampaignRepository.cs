namespace App.Repositories;

using App.Models;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

public class CampaignRepository(
    CheckoutDbContext dbContext
    )
{
    private readonly CheckoutDbContext _dbContext = dbContext;

    public async Task<List<Campaign>> GetAll() => await this._dbContext.Campaigns
            .Include(c => c.Products)
            .ToListAsync();

    public async Task<Campaign> FindOrFail(int id) => await this._dbContext.Campaigns
            .Where(c => c.Id == id)
            .Include(c => c.Products)
            .FirstOrDefaultAsync() ??
            throw new Exception("Campaign not exist.");

    public async Task<Campaign> Store(Campaign data)
    {
        this._dbContext.Campaigns.Add(data);
        await this._dbContext.SaveChangesAsync();

        return data;
    }

    public async Task<Campaign> Update(Campaign oldCampaign, Campaign newCampaign)
    {
        oldCampaign.Products = newCampaign.Products?.ToList();
        this._dbContext.Entry(oldCampaign).CurrentValues.SetValues(newCampaign);
        await this._dbContext.SaveChangesAsync();

        return newCampaign;
    }

    public async Task Delete(Campaign campaign)
    {
        this._dbContext.Remove(campaign);
        await this._dbContext.SaveChangesAsync();
    }
}
