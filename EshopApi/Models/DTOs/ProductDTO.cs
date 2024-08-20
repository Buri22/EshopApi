namespace EshopApi.Presentation.Models.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
