using App.DTOs;
using App.Models;
using App.Repositories;

namespace App.Services
{
    public class CampaignService
    {
        private readonly CampaignRepository _campaignRepository;
        private readonly ProductService _productService;

        public CampaignService(
            CampaignRepository campaignRepository,
            ProductService productService
        )
        {
            _campaignRepository = campaignRepository;
            _productService = productService;
        }

        public async Task<List<Campaign>> GetAll()
        {
            return await _campaignRepository.GetAll();
        }

        public async Task<Campaign> GetById(int id)
        {
            return await _campaignRepository.FindOrFail(id);
        }

        public async Task<Campaign> Create(CampaignInputDTO campaignInputDTO)
        {
            Campaign campaign = new(
                campaignInputDTO.Title,
                campaignInputDTO.Active
            );

            return await _campaignRepository.Store(campaign);
        }

        public async Task<Campaign> Update(int id, CampaignInputDTO campaignInputDTO)
        {
            Campaign oldCampaign = await _campaignRepository.FindOrFail(id);

            Campaign updatedCampaign = new(
                campaignInputDTO.Title,
                campaignInputDTO.Active
            )
            {
                Id = oldCampaign.Id,
            };

            return await _campaignRepository.Update(oldCampaign, updatedCampaign);
        }

        public async Task Delete(int id)
        {
            await _campaignRepository.Delete(id);
        }
    }
}
