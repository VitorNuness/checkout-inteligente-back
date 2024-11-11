namespace Core.Test.Models;

using Core.Models;

public class CampaignTest
{
    [Fact]
    public void TestCampaignCanBeCreated()
    {
        var title = "Campaign";

        var campaign = new Campaign(
            title: title
        );

        Assert.IsType<int>(campaign.Id);
        Assert.Equal(title, campaign.Title);
    }

    [Fact]
    public void TestDefaultCampaignValues()
    {
        var imageUrl = "http://localhost:5102/files/images/campaigns/0.png";

        var campaign = new Campaign(
            title: "Campaign"
        );

        Assert.True(campaign.Active);
        Assert.Equal(imageUrl, campaign.ImageUrl);
    }
}
