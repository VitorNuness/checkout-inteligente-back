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

        public async List<Campaign>? GetAll()
        {
            return _campaignRepository.GetAll();
        }

        public async Task<Campaign> GetById(int id)
        {
           return await _campaignRepository.FindOrFail(id);
        }

        public async void Create(Campaign data)
        {
            _campaignRepository.Store(data);
        }

        public async void Update(int id, Campaign data)
        {
            _campaignRepository.Update(id, data);
        }

        public async void Delete(int id)
        {
            _campaignRepository.Delete(id);
        }
    }
}
