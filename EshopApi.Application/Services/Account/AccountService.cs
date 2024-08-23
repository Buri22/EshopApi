using EshopApi.Application.Repositories;
using EshopApi.Application.Services;
using EshopApi.Domain.Entities;

namespace EshopApi.Application.Services
{
    public class AccountService(IAccountRepository accountRepository) : IAccountService
    {
        public bool IsValidAccountCredentials(Guid accountId, string accountSecret)
        {
            var account = accountRepository.GetAccountById(accountId);
            if (account == null || account.Secret != accountSecret) return false;

            return true;
        }

        public Account? GetAccountById(Guid accountId)
        {
            return accountRepository.GetAccountById(accountId);
        }
    }
}
