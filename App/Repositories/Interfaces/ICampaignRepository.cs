namespace App.Repositories.Interfaces;

using System.Collections.Generic;
using App.Models;

public interface ICampaignRepository
{
    public List<Campaign>? GetAll(string? sort = null);
    public Campaign? Get(int id);
    public void Store(Campaign data);
    public void Update(int id, Campaign data);
    public void Delete(int id);
}
