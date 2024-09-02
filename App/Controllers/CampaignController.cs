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
        public ActionResult<List<Campaign>> Index(string? sort = null)
        {
            return _campaignService.GetAll(sort);
        }

        [HttpGet("{id}")]
        public ActionResult<Campaign> Show(int id, string? sort)
        {
            Campaign? campaign = _campaignService.GetById(id, sort);
            if (campaign != null)
            {
                return campaign;
            }

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Campaign> Store(Campaign campaign)
        {
            _campaignService.Create(campaign);

            return campaign;
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Update(int id, Campaign campaign)
        {
            _campaignService.Update(id, campaign);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _campaignService.Delete(id);

            return NoContent();
        }
    }
}
