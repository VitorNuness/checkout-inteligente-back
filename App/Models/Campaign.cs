using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Campaign
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public bool Active { get; set; }
        public string? ImageUrl { get; set; } = "http://localhost:5102/files/images/campaigns/0.png";

        public Campaign(string? title, bool active)
        {
            this.Title = title;
            this.Active = active;
        }

        private Campaign() { }
    }
}
