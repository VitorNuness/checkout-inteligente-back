namespace Core.DTOs;

public class ReportDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? Reference { get; set; }
    public string? CreatedAt { get; set; }

    public ReportDTO(
        int? id,
        string? name,
        string? url,
        string? reference,
        string createdAt
    )
    {
        this.Id = id;
        this.Name = name;
        this.Url = url;
        this.Reference = reference;
        this.CreatedAt = createdAt;
    }
}
