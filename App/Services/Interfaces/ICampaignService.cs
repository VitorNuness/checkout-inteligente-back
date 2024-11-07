namespace App.Services.Interfaces;

using System.Collections.Generic;
using App.Models;

public interface ICampaignService
{
    public List<Campaign>? GetAll(string? sort = null);
    public Campaign? GetById(int id, string? sort = null);
    public void Create(Campaign data);
    public void Update(int id, Campaign data);
    public void Delete(int id);
}
