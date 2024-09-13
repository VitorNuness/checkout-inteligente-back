using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/campaigns")]
    public class CampaignController : ControllerBase
    {
        private readonly CampaignService _campaignService;

        public CampaignController(
            CampaignService campaignService
        )
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        public  async ActionResult<List<Campaign>> Index()
        {
            return _campaignService.GetAll();
        }

        [HttpGet("{id}")]
        public async ActionResult<Campaign> Show(int id)
        {
            Campaign? campaign = _campaignService.GetById(id);
            if (campaign != null)
            {
                return campaign;
            }

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async ActionResult<Campaign> Store(Campaign campaign)
        {
            _campaignService.Create(campaign);

            return campaign;
        }

        [Authorize]
        [HttpPut("{id}")]
        public async ActionResult Update(int id, Campaign campaign)
        {
            _campaignService.Update(id, campaign);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async ActionResult Delete(int id)
        {
            _campaignService.Delete(id);

            return NoContent();
        }
    }
}
