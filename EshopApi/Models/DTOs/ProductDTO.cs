using System.ComponentModel.DataAnnotations;

namespace EshopApi.Presentation.Models.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string ImageUrl { get; set; }
        [Required]
        public required decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
