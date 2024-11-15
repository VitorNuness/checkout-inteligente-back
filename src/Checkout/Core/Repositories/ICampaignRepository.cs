namespace Core.Repositories;

using Core.Models;

public interface ICampaignRepository
{
    public Task<List<Campaign>> GetAll();
    public Task<Campaign> FindOrFail(int id);
    public Task<Campaign> Store(Campaign campaign);
    public Task<Campaign> Update(Campaign oldCampaign, Campaign newCampaign);
    public Task Delete(Campaign campaign);
}
