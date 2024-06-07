using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly CampaignRepository Repository;

        public CampaignService()
        {
            this.Repository = new CampaignRepository();
        }

        public List<Campaign>? GetAll(string? sort = null)
        {
            return this.Repository.GetAll(sort);
        }

        public Campaign? GetById(int id, string? sort = null)
        {
            Campaign? campaign = this.Repository.Get(id);

            if (campaign == null)
            {
                return campaign;
            }

            if (sort == "trend")
            {
                if (campaign.Products != null)
                {
                    campaign.Products = campaign.Products.OrderByDescending(p => p.Views).ToList();
                    return campaign;
                }
            }

            return campaign;
        }

        public void Create(Campaign data)
        {
            this.Repository.Store(data);
        }

        public void Update(int id, Campaign data)
        {
            this.Repository.Update(id, data);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }
    }
}
