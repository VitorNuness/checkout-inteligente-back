using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Database;
using App.Models;
using App.Repositories.Interfaces;

namespace App.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly CheckoutDbContext DbContext;

        public CampaignRepository()
        {
            this.DbContext = new CheckoutDbContext();
        }

        public List<Campaign> GetAll()
        {
            return this.DbContext.Campaigns.ToList();
        }

        public Campaign Get(int id)
        {
            return this.DbContext.Campaigns.Where(c => c.Id == id).First();
        }

        public void Store(Campaign data)
        {
            this.DbContext.Campaigns.Add(data);
            this.DbContext.SaveChanges();
        }

        public void Update(int id, Campaign data)
        {
            Campaign campaign = this.Get(id);
            this.DbContext.Campaigns.Update(campaign);
            this.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Campaign campaign = this.Get(id);
            this.DbContext.Campaigns.Remove(campaign);
            this.DbContext.SaveChanges();
        }
    }
}
