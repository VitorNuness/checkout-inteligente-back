using App.Models;
using App.Repositories;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Hosting; // Para IWebHostEnvironment
using Microsoft.AspNetCore.Http; // Para IFormFile
using System.IO; // Para Path

namespace App.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly CampaignRepository _campaignRepository;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CampaignService(
            CampaignRepository campaignRepository,
            IFileService fileService,
            IWebHostEnvironment webHostEnvironment
        )
        {
            _campaignRepository = campaignRepository;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }

        // Métodos auxiliares para obter o caminho físico e a URL da imagem
        private string GetCampaignImagesPath(int campaignId)
        {
            return Path.Combine(_webHostEnvironment.WebRootPath, "files/images/campaigns", $"{campaignId}.jpg");
        }

        private string GetCampaignImagesUrl(int campaignId)
        {
            return $"/files/images/campaigns/{campaignId}.jpg";
        }

        public async Task<List<Campaign>?> GetAll()
        {
            return _campaignRepository.GetAll();
        }

        public async Task<Campaign> GetById(int id)
        {
            return await _campaignRepository.FindOrFail(id);
        }

        public async Task<Campaign> Create(CampaignInputDTO campaignInputDTO, IFormFile? image)
        {
            // Criar a nova campanha com base nos dados do DTO
            Campaign campaign = new(
                campaignInputDTO.Name,
                campaignInputDTO.StartDate,
                campaignInputDTO.EndDate,
                campaignInputDTO.DiscountPercentage
            );

            // Armazenar a nova campanha no banco de dados
            await _campaignRepository.Store(campaign);

            // Se uma imagem for fornecida, salvar a imagem e definir a URL
            if (image?.Length > 0)
            {
                string path = GetCampaignImagesPath(campaign.Id);
                await _fileService.SaveFile(image, path);

                campaign.ImageUrl = GetCampaignImagesUrl(campaign.Id);
                await _campaignRepository.Update(campaign, campaign); // Atualizar a campanha com a URL da imagem
            }

            return campaign;
        }

        public async Task<Campaign> Update(int id, CampaignInputDTO campaignInputDTO, IFormFile? image)
        {
            // Buscar a campanha existente
            Campaign oldCampaign = await _campaignRepository.FindOrFail(id);

            // Atualizar os dados da campanha com as novas informações
            Campaign updatedCampaign = new(
                campaignInputDTO.Name,
                campaignInputDTO.StartDate,
                campaignInputDTO.EndDate,
                campaignInputDTO.DiscountPercentage
            )
            {
                Id = oldCampaign.Id,
                ImageUrl = oldCampaign.ImageUrl // Manter a URL da imagem existente, se não houver nova imagem
            };

            // Se uma nova imagem for fornecida, salvá-la e definir a nova URL
            if (image?.Length > 0)
            {
                string path = GetCampaignImagesPath(updatedCampaign.Id);
                await _fileService.SaveFile(image, path);

                updatedCampaign.ImageUrl = GetCampaignImagesUrl(updatedCampaign.Id);
            }

            return await _campaignRepository.Update(oldCampaign, updatedCampaign);
        }

        public async Task Delete(int id)
        {
            Campaign campaign = await _campaignRepository.FindOrFail(id);
            await _campaignRepository.Delete(campaign);

            // Verificar se há uma imagem associada e removê-la
            if (campaign.ImageUrl != GetCampaignImagesUrl(0))
            {
                await _fileService.RemoveFile(GetCampaignImagesPath(id));
            }
        }
    }
}
