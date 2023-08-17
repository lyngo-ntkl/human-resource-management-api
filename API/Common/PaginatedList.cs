namespace API.Common
{
    public class PaginatedList<T> : List<T>
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int TotalPages{ get; set; }
        public int CurrentPage { get; set; }
        public bool HasNext => CurrentPage < TotalPages;
        public bool HasPrevious => CurrentPage > 1;
    }
}
