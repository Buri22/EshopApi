using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EshopApi.Infrastructure.Data.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string ImgUri { get; set; }

        [Required]
        [Precision(14, 2)]
        public decimal Price { get; set; }

        public string? Description { get; set; }
    }
}
