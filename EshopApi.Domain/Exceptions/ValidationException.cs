namespace EshopApi.Domain.Exceptions
{
    public class ValidationException(string message) : AppBaseException($"Validation exception: {message}")
    {
    }
}
