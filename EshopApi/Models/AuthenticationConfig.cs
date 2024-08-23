namespace EshopApi.Presentation.Models
{
    public class AuthenticationConfig
    {
        public string? Secret { get; set; }
        public int TokenExpiration { get; set; }
    }
}
