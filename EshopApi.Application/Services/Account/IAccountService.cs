using EshopApi.Domain.Entities;

namespace EshopApi.Application.Services
{
    public interface IAccountService
    {
        bool IsValidAccountCredentials(Guid accountId, string accountSecret);
        Account? GetAccountById(Guid accountId);
    }
}
