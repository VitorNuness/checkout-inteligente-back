namespace App.DTOs;

using System.Text.Json.Serialization;

public class CampaignInputDTO
{
    public string? Title { get; set; }
    [JsonRequired] public bool Active { get; set; }
    public List<int>? ProductsId { get; set; }
}
