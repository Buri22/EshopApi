using AutoMapper;
using EshopApi.Application.Repositories;
using EshopApi.Domain.Entities;
using EshopApi.Infrastructure.Data.DbContexts;
using EshopApi.Infrastructure.Data.Mapping;

namespace EshopApi.Infrastructure.Repositories
{
    public class AccountRepository(EshopDbContext context) : IAccountRepository
    {
        private readonly IMapper _mapper = MappingConfig.CreateMapper();

        public Account? GetAccountById(Guid id)
        {
            var accountEntity = context.AccountEntities.Find(id);
            return accountEntity != null ? _mapper.Map<Account>(accountEntity) : null;
        }
    }
}
