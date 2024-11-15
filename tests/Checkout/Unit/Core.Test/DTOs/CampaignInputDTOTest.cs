namespace Core.Test.DTOs;

using Core.DTOs;

public class CampaignInputDTOTest
{
    [Fact]
    public void TestCampaignInputDTOCanBeCreated()
    {
        var title = "Campaign";
        var active = true;
        List<int?> productsId = [1, 2, 3];

        var campaignInputDTO = new CampaignInputDTO(
            title: title,
            active: active,
            productsId: productsId
        );

        Assert.Equal(title, campaignInputDTO.Title);
        Assert.Equal(active, campaignInputDTO.Active);
        Assert.Equal(productsId, campaignInputDTO.ProductsId);
    }
}
