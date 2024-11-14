namespace App.Controllers;

using Core.Services;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/campaigns")]
public class CampaignController(
    ICampaignService campaignService
    ) : ControllerBase
{
    private readonly ICampaignService _campaignService = campaignService;

    [HttpGet]
    public async Task<ActionResult<List<Campaign>>> Index() => this.Ok(await this._campaignService.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<Campaign>> Show(int id)
    {
        var campaign = await this._campaignService.GetById(id);
        if (campaign != null)
        {
            return campaign;
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Campaign>> Store(
        [FromForm] CampaignInputDTO campaignInputDTO,
        IFormFile? image = null
        ) => this.CreatedAtAction(nameof(Store), await this._campaignService.Create(campaignInputDTO, image));

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(
        int id,
        [FromForm] CampaignInputDTO campaignInputDTO,
        IFormFile? image = null
        )
    {
        await this._campaignService.Update(id, campaignInputDTO, image);

        return this.NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await this._campaignService.Delete(id);

        return this.NoContent();
    }
}
