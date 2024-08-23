namespace EshopApi.Presentation.Models.DTOs
{
    public class LoginDTO
    {
        public Guid AccountId { get; set; }
        public required string AccountSecret { get; set; }
    }
}
