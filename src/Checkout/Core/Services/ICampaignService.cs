namespace Core.Services;

using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Http;

public interface ICampaignService
{
    public Task<List<Campaign>> GetAll();

    public Task<Campaign> GetById(int id);

    public Task<Campaign> Create(CampaignInputDTO campaignInputDTO, IFormFile? image);

    public Task<Campaign> Update(int id, CampaignInputDTO campaignInputDTO, IFormFile? image);

    public Task Delete(int id);
}
