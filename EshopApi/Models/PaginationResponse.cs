namespace EshopApi.Presentation.Models
{
    public class PaginationResponse<T>(IEnumerable<T> data, int totalCount, int page, int pageSize)
    {
        public IEnumerable<T> Data { get; set; } = data;
        public int TotalCount { get; set; } = totalCount;
        public int Page { get; set; } = page;
        public int PageSize { get; set; } = pageSize;
    }
}
