using EshopApi.Domain.Entities;

namespace EshopApi.Application.Repositories
{
    public interface IAccountRepository
    {
        Account? GetAccountById(Guid id);
    }
}
