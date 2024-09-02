using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly CampaignRepository _campaignRepository;

        public CampaignService(
            CampaignRepository campaignRepository
        )
        {
            _campaignRepository = campaignRepository;
        }

        public List<Campaign>? GetAll(string? sort = null)
        {
            return _campaignRepository.GetAll(sort);
        }

        public Campaign? GetById(int id, string? sort = null)
        {
            Campaign? campaign = _campaignRepository.Get(id);

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
            _campaignRepository.Store(data);
        }

        public void Update(int id, Campaign data)
        {
            _campaignRepository.Update(id, data);
        }

        public void Delete(int id)
        {
            _campaignRepository.Delete(id);
        }
    }
}
