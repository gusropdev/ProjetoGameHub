using GameHub.Domain.Enums;

namespace GameHub.Application.Common.Responses;

public class PagedResult<T> : Result<List<T>>
{
    public int TotalCount { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
    
    private PagedResult(
        bool isSuccess,
        List<T> data,
        List<string> errors,
        ErrorType errorType,
        int totalCount,
        int pageNumber,
        int pageSize) : base (isSuccess, data, errors, errorType)
    {
        TotalCount = totalCount;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    public static PagedResult<T> Success(List<T> data, int totalCount, int pageNumber, int pageSize)
        => new(true, data, [], ErrorType.None, totalCount, pageNumber, pageSize);

    public new static PagedResult<T> Failure(List<string> errors, ErrorType errorType = ErrorType.Validation)
        => new(false, [], errors, errorType, 0, 0, 0);
    
    public new static PagedResult<T> Failure(string error, ErrorType errorType = ErrorType.Validation)
        => new(false, [], [error], errorType, 0, 0, 0);
}