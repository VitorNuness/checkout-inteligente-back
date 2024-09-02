using System.Diagnostics.CodeAnalysis;

namespace App.DTOs
{
    public class CategoryInputDTO
    {
        public required string Name { get; set; }

        [SetsRequiredMembers]
        public CategoryInputDTO(
            string name
        )
        {
            Name = name;
        }
    }
}
