using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Campaign
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<Product>? Products { get; set; }
        public bool Rule { get; set; }
        public string? ImagePath { get; set; }

        public Campaign(string? title, string? imagePath)
        {
            this.Title = title;
            this.Rule = true;
            this.ImagePath = imagePath;
        }

        private Campaign() { }
    }
}
