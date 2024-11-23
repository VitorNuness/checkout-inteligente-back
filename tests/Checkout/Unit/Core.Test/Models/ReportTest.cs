namespace Core.Test.Models;

using Core.Models;

public class ReportTest
{
    [Fact]
    public void TestReportCanBeCreated()
    {
        var name = "Report";
        var url = "Url";
        var reference = "Reference";

        var report = new Report(
            name: name,
            url: url,
            reference: reference
        );

        Assert.IsType<int>(report.Id);
        Assert.Equal(name, report.Name);
        Assert.Equal(url, report.Url);
        Assert.Equal(reference, report.Reference);
    }

    [Fact]
    public void TestDefaultValue()
    {
        var defaultCreatedAt = DateTime.Now.Date;

        var report = new Report(
            name: "Report",
            url: "Url",
            reference: "Reference"
        );

        Assert.Equal(defaultCreatedAt, report.CreatedAt.Date);
    }
}
