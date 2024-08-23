using System.ComponentModel.DataAnnotations;

namespace EshopApi.Domain.Entities
{
    public class AccountEntity
    {
        [Key]
        public required Guid Id { get; set; }

        [Required]
        public required string Secret { get; set; }
    }
}
