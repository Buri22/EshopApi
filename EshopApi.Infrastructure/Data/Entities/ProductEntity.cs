using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopApi.Infrastructure.Data.Entities
{
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

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
