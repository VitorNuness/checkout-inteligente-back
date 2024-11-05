using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
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
            Name = name;
            Url = url;
            Reference = reference;
        }

        private Report() { }
    }
}
