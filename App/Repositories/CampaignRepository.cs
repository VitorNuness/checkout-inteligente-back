using App.Models;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class CampaignRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public CampaignRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public async Task<List<Campaign>> GetAll()
        {
            return await _dbContext.Campaigns
                .Include(c => c.Products)
                .ToListAsync();
        }

        public async Task<Campaign> FindOrFail(int id)
        {
            return await _dbContext.Campaigns
                .Where(c => c.Id == id)
                .Include(c => c.Products)
                .FirstOrDefaultAsync() ??
                throw new Exception("Campaign not exist.");
        }

        public async Task<Campaign> Store(Campaign data)
        {
            _dbContext.Campaigns.Add(data);
            await _dbContext.SaveChangesAsync();

            return data;
        }

        public async Task<Campaign> Update(Campaign oldCampaign, Campaign newCampaign)
        {
            oldCampaign.Products = newCampaign.Products?.ToList();
            _dbContext.Entry(oldCampaign).CurrentValues.SetValues(newCampaign);
            await _dbContext.SaveChangesAsync();

            return newCampaign;
        }

        public async Task Delete(Campaign campaign)
        {
            _dbContext.Remove(campaign);
            await _dbContext.SaveChangesAsync();
        }
    }
}
