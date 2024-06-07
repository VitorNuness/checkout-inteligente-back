using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Models;

namespace App.Repositories.Interfaces
{
    public interface ICampaignRepository
    {
        public List<Campaign>? GetAll(string? sort = null);
        public Campaign? Get(int id);
        public void Store(Campaign data);
        public void Update(int id, Campaign data);
        public void Delete(int id);
    }
}
