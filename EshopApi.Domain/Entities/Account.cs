namespace EshopApi.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public required string Secret { get; set; }
    }
}
