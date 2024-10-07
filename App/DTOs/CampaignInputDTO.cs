namespace App.DTOs;

public class CampaignInputDTO
{
    public string? Title { get; set; }
    public bool Active { get; set; }
    public List<int>? ProductsId { get; set; }
}
