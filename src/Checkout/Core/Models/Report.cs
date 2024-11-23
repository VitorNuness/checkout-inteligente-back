namespace Core.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Report
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Reference { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Report(
        string name,
        string url,
        string reference
    )
    {
        this.Name = name;
        this.Url = url;
        this.Reference = reference;
    }

    public Report(
        int id,
        string name,
        string url,
        string reference,
        DateTime createdAt
    )
    {
        this.Id = id;
        this.Name = name;
        this.Url = url;
        this.Reference = reference;
        this.CreatedAt = createdAt;
    }

    private Report() { }
}
