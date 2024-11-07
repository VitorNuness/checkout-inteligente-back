using App.Models;

namespace App.DTOs
{
    public class ReportDTO(
        int? id,
        string? name,
        string? url,
        string? reference,
        string? createdAt
    )
    {
        public int? Id { get; set; } = id;
        public string? Name { get; set; } = name;
        public string? Url { get; set; } = url;
        public string? Reference { get; set; } = reference;
        public string? CreatedAt { get; set; } = createdAt;
    }
}
