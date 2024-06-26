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
        private readonly CampaignService Service;

        public CampaignController()
        {
            this.Service = new CampaignService();
        }

        [HttpGet]
        public ActionResult<List<Campaign>> Index(string? sort = null)
        {
            return this.Service.GetAll(sort);
        }

        [HttpGet("{id}")]
        public ActionResult<Campaign> Show(int id, string? sort)
        {
            Campaign? campaign = this.Service.GetById(id, sort);
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
            this.Service.Create(campaign);

            return campaign;
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Update(int id, Campaign campaign)
        {
            this.Service.Update(id, campaign);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this.Service.Delete(id);

            return NoContent();
        }
    }
}
