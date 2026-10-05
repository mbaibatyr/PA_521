namespace MyPagination.Model
{
    public class PagedResult<T>
    {
        public IReadOnlyList<T> Items { get; init; } = [];
        public int Page { get; init; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }

        public int TotalPages =>
            (int)Math.Ceiling((double)TotalCount / PageSize);

        public bool HasNextPage =>
            Page < TotalPages;

        public bool HasPreviousPage =>
            Page > 1;
    }
}
