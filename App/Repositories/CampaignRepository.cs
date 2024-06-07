using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Database;
using App.Models;
using App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly CheckoutDbContext DbContext;

        public CampaignRepository()
        {
            this.DbContext = new CheckoutDbContext();
        }

        public List<Campaign>? GetAll(string? sort = null)
        {
            List<Campaign>? campaigns = this.DbContext.Campaigns
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
            return this.DbContext.Campaigns
                .Include(c => c.Products)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public void Store(Campaign data)
        {
            this.DbContext.Campaigns.Add(data);
            this.DbContext.SaveChanges();
        }

        public void Update(int id, Campaign data)
        {
            Campaign? campaign = this.Get(id);
            if (campaign != null)
            {
                campaign.Id = id;
                this.DbContext.Entry(campaign).CurrentValues.SetValues(data);
            }

            this.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Campaign? campaign = this.Get(id);
            if (campaign != null)
            {
                this.DbContext.Campaigns.Remove(campaign);
            }
            this.DbContext.SaveChanges();
        }
    }
}
