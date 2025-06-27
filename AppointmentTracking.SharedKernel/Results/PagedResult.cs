namespace AppointmentTracking.SharedKernel.Results;

public class PagedResult<T> : Result<List<T>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

    public static PagedResult<T> Create(List<T> items, int page, int pageSize, int totalCount)
    {
        return new PagedResult<T>
        {
            Data = items,
            Success = true,
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }
}
