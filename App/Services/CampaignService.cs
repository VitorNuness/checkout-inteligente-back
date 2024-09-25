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

        public async Task<Campaign> Create(CampaignInputDTO campaignInputDTO,IFormFile? image)
        {
            IEnumerable<Product> products = [];

            if (campaignInputDTO.ProductsId?.Count > 0)
            {
                products = await _productService.GetWhereIds(campaignInputDTO.ProductsId);
            }

            Campaign campaign = new(
                campaignInputDTO.Title,
                campaignInputDTO.Active
            )
            {
                Products = products,
            };

            await _campaignRepository.Store(campaign);

            await Update(campaign.Id, campaignInputDTO, image);

            return campaign;
        }

        public async Task<Campaign> Update(int id, CampaignInputDTO campaignInputDTO,IFormFile? image)
        {
            IEnumerable<Product> products = [];

            if (campaignInputDTO.ProductsId?.Count > 0)
            {
                products = await _productService.GetWhereIds(campaignInputDTO.ProductsId);
            }

            Campaign oldCampaign = await _campaignRepository.FindOrFail(id);

            Campaign newCampaign = new(
                campaignInputDTO.Title,
                campaignInputDTO.Active
            )
            {
                Id = oldCampaign.Id,
                Products = products,
                ImageUrl = oldCampaign.ImageUrl,
            };
            if (image?.Length > 0)
            {
                string path = GetCampaignImagesPath(newCampaign.Id);
                await _fileService.SaveFile(image, path);

                newCampaign.ImageUrl = GetCampaignImagesUrl(newCampaign.Id);
            }

            return await _campaignRepository.Update(oldCampaign, newCampaign);
        }

        public async Task Delete(int id)
        {
            Campaign campaign = await GetById(id);
            await _campaignRepository.Delete(campaign);

            if (campaign.ImageUrl != GetCampaignImagesUrl(0))
            {
                await _fileService.RemoveFile(GetCampaignImagesPath(id));
            }
        }

         private string GetCampaignImagesPath(int id) => Path.Combine(_environment.WebRootPath, "files/images/categories", id.ToString() + ".png");

        private string GetCampaignImagesUrl(int id) => "http://localhost:5102/files/images/categories/" + id.ToString() + ".png";
    }
}
