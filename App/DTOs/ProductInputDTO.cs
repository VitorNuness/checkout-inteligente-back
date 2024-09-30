namespace App.DTOs
{
    public class ProductInputDTO
    {
        public string Name { get; set; }
        public double Quantity { get; set; } = 0;
        public double Price { get; set; } = 0;
        public int CategoryId { get; set; }
    }
}
