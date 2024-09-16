using App.Models;
using App.Repositories.Database;
using App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public CampaignRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public async List<Campaign>? GetAll()
        {
            return await _dbContext.Campaigns
                .Include(c => c.Products)
                .ToListAsync();


        }

        public async Campaign? FindOrFail(int id)
        {
            return await _dbContext.Campaigns.Where(c => c.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Campaign not exist.");
        }

        public async Task<Campaign> Store(Campaign data)
        {
            _dbContext.Campaigns.Add(data);
            await _dbContext.SaveChangesAsync();

            return data;
        }

        public async Task<Campaign> Update(Campaign oldCampaign, Campaign newCampaign)
        {
            _dbContext.Entry(oldCampaign).CurrentValues.SetValues(newCampaign);

            await _dbContext.SaveChangesAsync();


            return newCampaign;
        }

        public async void Delete(int id)
        {
            Campaign? campaign = this.Get(id);
            if (campaign != null)
            {
                _dbContext.Remove(campaign);
            }
            _dbContext.SaveChanges();
        }



}
