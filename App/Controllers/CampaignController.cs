using App.DTOs;
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
        public async Task<ActionResult<List<Campaign>>> Index()
        {
            return Ok(await _campaignService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Campaign>> Show(int id)
        {
            Campaign? campaign = await _campaignService.GetById(id);
            if (campaign != null)
            {
                return campaign;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Campaign>> Store(
            [FromForm] CampaignInputDTO campaignInputDTO,
            IFormFile? image = null
            )
        {
            return CreatedAtAction(nameof(Store), await _campaignService.Create(campaignInputDTO, image));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(
            int id,
            [FromForm] CampaignInputDTO campaignInputDTO,
            IFormFile? image = null
            )
        {
            await _campaignService.Update(id, campaignInputDTO, image);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _campaignService.Delete(id);

            return NoContent();
        }
    }
}
