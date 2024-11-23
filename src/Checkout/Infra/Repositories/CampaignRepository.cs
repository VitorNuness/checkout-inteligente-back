namespace Infra.Repositories;

using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Infra.Repositories.Database;

public class CampaignRepository : ICampaignRepository
{
    private readonly CheckoutDbContext _dbContext;

    public CampaignRepository(
        CheckoutDbContext dbContext
    ) => this._dbContext = dbContext;

    public async Task<List<Campaign>> GetAll() => await this._dbContext.Campaigns
            .Include(c => c.Products)
            .ToListAsync();

    public async Task<Campaign> FindOrFail(int id) => await this._dbContext.Campaigns
            .Where(c => c.Id == id)
            .Include(c => c.Products)
            .FirstOrDefaultAsync() ??
            throw new Exception("Campaign not exist.");

    public async Task<Campaign> Store(Campaign campaign)
    {
        this._dbContext.Campaigns.Add(campaign);
        await this._dbContext.SaveChangesAsync();

        return campaign;
    }

    public async Task<Campaign> Update(Campaign oldCampaign, Campaign newCampaign)
    {
        oldCampaign.Products = [.. newCampaign.Products];
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
