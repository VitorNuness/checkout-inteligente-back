using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Services.Interfaces
{
    public interface ICampaignService
    {
        public List<Campaign> GetAll();
        public Campaign? GetById(int id, string? sort = null);
        public void Create(Campaign data);
        public void Update(int id, Campaign data);
        public void Delete(int id);
    }
}
