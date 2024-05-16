namespace Ripple.API.Modules.Core.Dtos
{
    public class Response
    {
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; } = "Success";

    }

    public class Response<T> : Response where T : class
    {
        public T? Data { get; set; }
    }

    public class PaginationResponse<T> : Response where T : class
    {
        public T? Data { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}

