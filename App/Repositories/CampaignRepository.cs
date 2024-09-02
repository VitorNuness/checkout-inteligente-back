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

        public List<Campaign>? GetAll(string? sort = null)
        {
            List<Campaign>? campaigns = _dbContext.Campaigns
                .Include(c => c.Products)
                .ToList();

            if (campaigns != null)
            {
                if (sort == "active")
                {
                    campaigns = campaigns.Where(c => c.Active == true).ToList();
                }

                if (sort == "desactive")
                {
                    campaigns = campaigns.Where(c => c.Active == false).ToList();
                }
            }

            return campaigns;
        }

        public Campaign? Get(int id)
        {
            return _dbContext.Campaigns
                .Include(c => c.Products)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public void Store(Campaign data)
        {
            _dbContext.Campaigns.Add(data);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Campaign data)
        {
            Campaign? campaign = this.Get(id);
            if (campaign != null)
            {
                campaign.Id = id;
                _dbContext.Entry(campaign).CurrentValues.SetValues(data);
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Campaign? campaign = this.Get(id);
            if (campaign != null)
            {
                _dbContext.Remove(campaign);
            }
            _dbContext.SaveChanges();
        }
    }
}
