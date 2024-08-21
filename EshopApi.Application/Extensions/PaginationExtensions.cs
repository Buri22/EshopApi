using EshopApi.Domain.Exceptions;

namespace EshopApi.Application.Extensions
{
    public static class PaginationExtensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> enumerable, int page, int pageSize)
        {
            ValidatePaginationArguments(page, pageSize);
            return enumerable
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int page, int pageSize)
        {
            ValidatePaginationArguments(page, pageSize);
            return queryable
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        private static void ValidatePaginationArguments(int page, int pageSize)
        {
            if (page < 1 || pageSize < 1)
                throw new ValidationException($"Pagination arguments: page = {page} or pageSize = {pageSize} is invalid.");
        }
    }
}
