using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EshopApi.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgUri { get; set; }

        [Required]
        [Precision(14, 2)]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
