namespace Core.DTOs;

public class CategoryInputDTO
{
    public string Name { get; set; }

    public CategoryInputDTO(string name)
    {
        this.Name = name;
    }
}
