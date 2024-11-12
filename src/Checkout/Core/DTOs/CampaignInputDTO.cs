namespace Core.DTOs;

public class CampaignInputDTO
{
    public string Title { get; set; }
    public bool Active { get; set; }
    public List<int?> ProductsId { get; set; } = [];

    public CampaignInputDTO(
        string title,
        bool active,
        List<int?> productsId
    )
    {
        this.Title = title;
        this.Active = active;
        this.ProductsId = productsId;
    }
}
