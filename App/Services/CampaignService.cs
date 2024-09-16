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

        public async Task<Campaign> Create(CampaignInputDTO campaignInputDTO)
        {
            Campaign campaign = new(
                campaignInputDTO.Name,
                campaignInputDTO.StartDate,
                campaignInputDTO.EndDate,
                campaignInputDTO.DiscountPercentage
            );

            await _campaignRepository.Store(campaign);

            return campaign;

            if (image?.Length > 0)
            {
                string path = GetCampaignImagesPath(campaign.Id);
                await _fileService.SaveFile(image, path);

                campaign.ImageUrl = GetCampaignImagesUrl(campaign.Id);
                await _campaignRepository.Update(campaign, campaign);
            }
        }

        public async Task<Campaign> Update(int id, CampaignInputDTO campaignInputDTO)
        {
            Campaign oldCampaign = await _campaignRepository.FindOrFail(id);

            Campaign updatedCampaign = new(
                campaignInputDTO.Name,
                campaignInputDTO.StartDate,
                campaignInputDTO.EndDate,
                campaignInputDTO.DiscountPercentage
            )
            {       //processar imagem / upload
                Id = oldCampaign.Id,
                ImageUrl = oldCampaign.ImageUrl
            };

            if (campaignInputDTO.Image?.Length > 0)
            {
                string path = GetCampaignImagesPath(updatedCampaign.Id);
            }

            return await _campaignRepository.Update(oldCampaign, updatedCampaign):
        }

        public async void Delete(int id)
        {
            _campaignRepository.Delete(id);
        }
    }
}
